using GameAPI.Core.Domain;
using GameAPI.Core.Exceptions;
using GameAPI.Core.Persistence;
using GameAPI.Core.Services;
using NSubstitute;

namespace GameAPI.Core.UnitTests.Services;

public class GameRoundServiceTests
{
    private readonly IGameRoundRepository _repository;
    private readonly GameRoundService _gameRoundService;

    public GameRoundServiceTests()
    {
        _repository = Substitute.For<IGameRoundRepository>();
        _gameRoundService = new GameRoundService(_repository);
    }

    [Fact]
    public async Task AddRoundAsync_WhenCalled_AddsRoundToRepository()
    {
        // Arrange
        var gameRound = new GameRound(
            Guid.NewGuid(),
            1,
            2,
            RoundOutcome.Win,
            DateTimeOffset.UtcNow);

        // Act
        await _gameRoundService.AddRoundAsync(gameRound);

        // Assert
        await _repository.Received(1).AddAsync(gameRound);
    }

    [Fact]
    public async Task RemoveAllRoundsAsync_WhenCalled_RemovesAllRoundsFromRepository()
    {
        // Act
        var act = async () => await _gameRoundService.RemoveAllRoundsAsync();
        var exception = await Record.ExceptionAsync(act);

        // Assert
        Assert.Null(exception);
        await _repository.Received(1).RemoveAllAsync();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task GetLatestRoundsAsync_WhenCountIsLessOrEqualZero_ThrowsBadRequestException(int count)
    {
        // Act
        var act = () => _gameRoundService.GetLatestRoundsAsync(count);

        // Assert
        await Assert.ThrowsAsync<BadRequestException>(act);
        await _repository.DidNotReceive().GetLatestRoundsAsync(Arg.Any<int>());
    }

    [Fact]
    public async Task GetLatestRoundsAsync_WhenCalled_ReturnsLatestRounds()
    {
        // Arrange
        const int count = 5;
        var expectedRounds = new List<GameRound>
        {
            new(Guid.NewGuid(), 1, 2, RoundOutcome.Win, DateTimeOffset.UtcNow)
        };
        _repository.GetLatestRoundsAsync(count).Returns(expectedRounds);

        // Act
        var result = await _gameRoundService.GetLatestRoundsAsync(count);

        // Assert
        Assert.Equal(expectedRounds, result);
        await _repository.Received(1).GetLatestRoundsAsync(count);
    }
}