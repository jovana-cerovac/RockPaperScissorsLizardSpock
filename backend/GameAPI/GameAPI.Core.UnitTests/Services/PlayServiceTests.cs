using GameAPI.Core.Contracts;
using GameAPI.Core.Domain;
using GameAPI.Core.Exceptions;
using GameAPI.Core.Services;
using GameAPI.Core.Services.Abstractions;
using NSubstitute;

namespace GameAPI.Core.UnitTests.Services;

public class PlayServiceTests
{
    private readonly IChoicesApiClient _choicesApiClient;
    private readonly IGameRoundService _gameRoundService;
    private readonly IRulesService _rulesService;
    private readonly IChoiceValidator _choiceValidator;
    private readonly PlayService _playService;

    public PlayServiceTests()
    {
        _choicesApiClient = Substitute.For<IChoicesApiClient>();
        _gameRoundService = Substitute.For<IGameRoundService>();
        _rulesService = Substitute.For<IRulesService>();
        _choiceValidator = Substitute.For<IChoiceValidator>();

        _playService = new PlayService(
            _choicesApiClient,
            _gameRoundService,
            _rulesService,
            _choiceValidator);
    }

    [Fact]
    public async Task PlayRoundAsync_WithValidChoices_ReturnLoseResult_AndAddsNewGameRound()
    {
        // Arrange
        var playRequest = new PlayRequest
        {
            Player = 1
        };
        var playerChoice = new ChoiceResponse
        {
            Id = 1,
            Name = "Rock"
        };
        var computerChoice = new ChoiceResponse
        {
            Id = 2,
            Name = "Paper"
        };

        _choicesApiClient
            .GetChoiceByIdAsync(playRequest.Player)
            .Returns(playerChoice);

        _choicesApiClient
            .GetRandomChoiceAsync()
            .Returns(computerChoice);

        _rulesService
            .DetermineOutcome(ChoiceType.Rock, ChoiceType.Paper)
            .Returns(RoundOutcome.Lose);

        // Act
        var result = await _playService.PlayRoundAsync(playRequest);

        // Assert
        Assert.Equal(nameof(RoundOutcome.Lose), result.Results);
        Assert.Equal(playerChoice.Id, result.Player);
        Assert.Equal(computerChoice.Id, result.Computer);

        await _choicesApiClient.Received(1).GetChoiceByIdAsync(Arg.Any<int>());
        await _choicesApiClient.Received(1).GetRandomChoiceAsync();
        _rulesService.Received(1).DetermineOutcome(
            Arg.Any<ChoiceType>(),
            Arg.Any<ChoiceType>());
        await _gameRoundService.Received(1).AddRoundAsync(Arg.Any<GameRound>());
    }

    [Fact]
    public async Task PlayRoundAsync_WithValidChoices_WhenSameChoices_ReturnsTie_AndAddsNewGameRound()
    {
        // Arrange
        var playRequest = new PlayRequest
        {
            Player = 1
        };
        var choice = new ChoiceResponse
        {
            Id = 1, Name = "Rock"
        };

        _choicesApiClient
            .GetChoiceByIdAsync(playRequest.Player)
            .Returns(choice);

        _choicesApiClient
            .GetRandomChoiceAsync()
            .Returns(choice);

        _rulesService
            .DetermineOutcome(ChoiceType.Rock, ChoiceType.Rock)
            .Returns(RoundOutcome.Tie);

        // Act
        var result = await _playService.PlayRoundAsync(playRequest);

        // Assert
        Assert.Equal(nameof(RoundOutcome.Tie), result.Results);
        Assert.Equal(choice.Id, result.Player);
        Assert.Equal(choice.Id, result.Computer);

        await _choicesApiClient.Received(1).GetChoiceByIdAsync(Arg.Any<int>());
        await _choicesApiClient.Received(1).GetRandomChoiceAsync();
        _rulesService.Received(1).DetermineOutcome(
            Arg.Any<ChoiceType>(),
            Arg.Any<ChoiceType>());
        await _gameRoundService.Received(1).AddRoundAsync(Arg.Any<GameRound>());
    }


    [Fact]
    public async Task PlayRoundAsync_WithValidChoices_WhenPlayerWins_ReturnsWinResult_AndAddsNewGameRound()
    {
        // Arrange
        var playRequest = new PlayRequest
        {
            Player = 2
        };
        var playerChoice = new ChoiceResponse
        {
            Id = 2, Name = "Rock"
        };
        var computerChoice = new ChoiceResponse
        {
            Id = 1, Name = "Rock"
        };

        _choicesApiClient
            .GetChoiceByIdAsync(playRequest.Player)
            .Returns(playerChoice);

        _choicesApiClient
            .GetRandomChoiceAsync()
            .Returns(computerChoice);

        _rulesService
            .DetermineOutcome(ChoiceType.Paper, ChoiceType.Rock)
            .Returns(RoundOutcome.Win);

        // Act
        var result = await _playService.PlayRoundAsync(playRequest);

        // Assert
        Assert.Equal(nameof(RoundOutcome.Win), result.Results);
        Assert.Equal(playerChoice.Id, result.Player);
        Assert.Equal(computerChoice.Id, result.Computer);

        await _choicesApiClient.Received(1).GetChoiceByIdAsync(Arg.Any<int>());
        await _choicesApiClient.Received(1).GetRandomChoiceAsync();
        _rulesService.Received(1).DetermineOutcome(
            Arg.Any<ChoiceType>(),
            Arg.Any<ChoiceType>());
        await _gameRoundService.Received(1).AddRoundAsync(Arg.Any<GameRound>());
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(100)]
    public async Task PlayRoundAsync_WithInvalidPlayerChoice_ThrowsBadRequestException(int playerChoiceId)
    {
        // Arrange
        var playRequest = new PlayRequest
        {
            Player = playerChoiceId
        };

        _choiceValidator
            .When(v => v.ValidateChoiceId(playerChoiceId))
            .Throw(new BadRequestException($"Invalid Choice ID value {playerChoiceId}"));

        // Act & Assert
        await Assert.ThrowsAsync<BadRequestException>(() => _playService.PlayRoundAsync(playRequest));
    }

    [Fact]
    public async Task PlayRoundAsync_WhenComputerChoiceInvalid_ThrowsBadRequestException()
    {
        // Arrange
        var playRequest = new PlayRequest
        {
            Player = 1
        };
        var playerChoice = new ChoiceResponse
        {
            Id = 1,
            Name = "Rock"
        };
        var invalidComputerChoice = new ChoiceResponse
        {
            Id = 99,
            Name = "Invalid"
        };

        _choicesApiClient
            .GetChoiceByIdAsync(playRequest.Player)
            .Returns(playerChoice);

        _choicesApiClient
            .GetRandomChoiceAsync()
            .Returns(invalidComputerChoice);

        _choiceValidator
            .When(v => v.ValidateChoiceId(invalidComputerChoice.Id))
            .Throw(new BadRequestException($"Invalid Choice ID value {invalidComputerChoice.Id}"));

        // Act & Assert
        await Assert.ThrowsAsync<BadRequestException>(() => _playService.PlayRoundAsync(playRequest));
    }
}