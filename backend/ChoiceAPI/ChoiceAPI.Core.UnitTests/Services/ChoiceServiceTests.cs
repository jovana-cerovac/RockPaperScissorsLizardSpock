using ChoiceAPI.Core.Constants;
using ChoiceAPI.Core.Contracts;
using ChoiceAPI.Core.Domain;
using ChoiceAPI.Core.Exceptions;
using ChoiceAPI.Core.Persistence;
using ChoiceAPI.Core.Services;
using ChoiceAPI.Core.Services.Abstractions;
using NSubstitute;

namespace ChoiceAPI.Core.UnitTests.Services;

public class ChoiceServiceTests
{
    private readonly IChoiceRepository _choiceRepository;
    private readonly IRandomNumberService _randomNumberService;
    private readonly ChoiceService _choiceService;

    public ChoiceServiceTests()
    {
        _choiceRepository = Substitute.For<IChoiceRepository>();
        _randomNumberService = Substitute.For<IRandomNumberService>();
        _choiceService = new ChoiceService(_choiceRepository, _randomNumberService);
    }

    [Fact]
    public async Task GetAll_ReturnsAllChoices()
    {
        // Arrange
        var choices = new List<Choice>
        {
            new RockChoice(),
            new ScissorsChoice()
        };
        _choiceRepository.GetAllChoicesAsync().Returns(choices);

        // Act
        var result = (await _choiceService.GetAllChoicesAsync()).ToList();

        // Assert
        Assert.Equal(choices.Count, result.Count);
        Assert.All(result, r => Assert.IsType<ChoiceResponse>(r));
    }

    [Fact]
    public async Task GetRandomChoice_WhenChoiceExists_ReturnsChoice()
    {
        // Arrange
        var expectedChoice = new RockChoice();
        _randomNumberService.GetRandomNumberAsync().Returns(0);
        _choiceRepository.GetTotalCountAsync().Returns(5);
        _choiceRepository.GetByIdAsync(1).Returns(expectedChoice);

        // Act
        var result = await _choiceService.GetRandomChoiceAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedChoice.Id, result.Id);

        await _randomNumberService.Received(1).GetRandomNumberAsync();
        await _choiceRepository.Received(1).GetTotalCountAsync();
        await _choiceRepository.Received(1).GetByIdAsync(1); // 0 % 5 + 1 = 3
    }

    [Fact]
    public async Task GetRandomChoice_WhenChoiceNotFound_ThrowsNotFoundException()
    {
        // Arrange
        _randomNumberService.GetRandomNumberAsync().Returns(0);
        _choiceRepository.GetTotalCountAsync().Returns(5);
        _choiceRepository.GetByIdAsync(Arg.Any<int>()).Returns((Choice?)null);

        // Act
        var act = async () => await _choiceService.GetRandomChoiceAsync();

        // Asserts
        await Assert.ThrowsAsync<NotFoundException>(act);
        await _randomNumberService.Received(1).GetRandomNumberAsync();
        await _choiceRepository.Received(1).GetTotalCountAsync();
        await _choiceRepository.Received(1).GetByIdAsync(1); // 0 % 5 + 1 = 3
    }

    [Fact]
    public async Task GetChoiceById_WhenChoiceExists_ReturnsChoice()
    {
        // Arrange
        const int id = ChoiceConstants.MinChoiceId + 1;
        var expectedChoice = new PaperChoice();
        _choiceRepository.GetByIdAsync(id).Returns(expectedChoice);

        // Act
        var result = await _choiceService.GetChoiceByIdAsync(id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedChoice.Id, result.Id);
        await _choiceRepository.Received(1).GetByIdAsync(id);
    }

    [Theory]
    [InlineData(ChoiceConstants.MinChoiceId - 1)]
    [InlineData(ChoiceConstants.MaxChoiceId + 1)]
    public async Task GetChoiceById_WhenIdIsInvalid_ThrowsBadRequestException(int invalidId)
    {
        // Act
        var act = async () => await _choiceService.GetChoiceByIdAsync(invalidId);

        // Assert
        await Assert.ThrowsAsync<BadRequestException>(act);
        await _choiceRepository.DidNotReceive().GetByIdAsync(Arg.Any<int>());
    }

    [Fact]
    public async Task GetChoiceById_WhenChoiceNotFound_ThrowsNotFoundException()
    {
        // Arrange
        _choiceRepository.GetByIdAsync(Arg.Any<int>()).Returns((Choice?)null);

        // Act
        var act = async () => await _choiceService.GetChoiceByIdAsync(1);

        // Assert
        await Assert.ThrowsAsync<NotFoundException>(act);
        await _choiceRepository.Received(1).GetByIdAsync(Arg.Any<int>());
    }
}