using GameAPI.Core.Domain;
using GameAPI.Core.Services;

namespace GameAPI.Core.UnitTests.Services;

public class RulesServiceTests
{
    private readonly RulesService _rulesService = new();

    [Theory]
    [InlineData(ChoiceType.Rock)]
    [InlineData(ChoiceType.Paper)]
    [InlineData(ChoiceType.Scissors)]
    public void DetermineOutcome_WhenSameChoices_ReturnsTie(ChoiceType choice)
    {
        // Act
        var result = _rulesService.DetermineOutcome(choice, choice);

        // Assert
        Assert.Equal(RoundOutcome.Tie, result);
    }

    [Theory]
    [InlineData(ChoiceType.Rock, ChoiceType.Scissors)]
    [InlineData(ChoiceType.Rock, ChoiceType.Lizard)]
    [InlineData(ChoiceType.Paper, ChoiceType.Rock)]
    [InlineData(ChoiceType.Paper, ChoiceType.Spock)]
    [InlineData(ChoiceType.Scissors, ChoiceType.Paper)]
    [InlineData(ChoiceType.Scissors, ChoiceType.Lizard)]
    [InlineData(ChoiceType.Lizard, ChoiceType.Spock)]
    [InlineData(ChoiceType.Lizard, ChoiceType.Paper)]
    [InlineData(ChoiceType.Spock, ChoiceType.Scissors)]
    [InlineData(ChoiceType.Spock, ChoiceType.Rock)]
    public void DetermineOutcome_WhenPlayerWins_ReturnsWin(ChoiceType playerChoice, ChoiceType computerChoice)
    {
        // Act
        var result = _rulesService.DetermineOutcome(playerChoice, computerChoice);

        // Assert
        Assert.Equal(RoundOutcome.Win, result);
    }

    [Theory]
    [InlineData(ChoiceType.Rock, ChoiceType.Paper)]
    [InlineData(ChoiceType.Rock, ChoiceType.Spock)]
    [InlineData(ChoiceType.Paper, ChoiceType.Scissors)]
    [InlineData(ChoiceType.Paper, ChoiceType.Lizard)]
    [InlineData(ChoiceType.Scissors, ChoiceType.Rock)]
    [InlineData(ChoiceType.Scissors, ChoiceType.Spock)]
    [InlineData(ChoiceType.Lizard, ChoiceType.Rock)]
    [InlineData(ChoiceType.Lizard, ChoiceType.Scissors)]
    [InlineData(ChoiceType.Spock, ChoiceType.Paper)]
    [InlineData(ChoiceType.Spock, ChoiceType.Lizard)]
    public void DetermineOutcome_WhenPlayerLoses_ReturnsLose(ChoiceType playerChoice, ChoiceType computerChoice)
    {
        // Act
        var result = _rulesService.DetermineOutcome(playerChoice, computerChoice);

        // Assert
        Assert.Equal(RoundOutcome.Lose, result);
    }
}