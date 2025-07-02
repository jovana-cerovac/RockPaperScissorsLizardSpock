using GameAPI.Core.Domain;

namespace GameAPI.Core.Services;

public static class GameRules //TODO: Find better place?
{
    private static readonly List<Rule> Rules = new()
    {
        new Rule(ChoiceType.Rock, ChoiceType.Scissors),
        new Rule(ChoiceType.Rock, ChoiceType.Lizard),
        new Rule(ChoiceType.Paper, ChoiceType.Rock),
        new Rule(ChoiceType.Paper, ChoiceType.Spock),
        new Rule(ChoiceType.Scissors, ChoiceType.Paper),
        new Rule(ChoiceType.Scissors, ChoiceType.Lizard),
        new Rule(ChoiceType.Lizard, ChoiceType.Spock),
        new Rule(ChoiceType.Lizard, ChoiceType.Paper),
        new Rule(ChoiceType.Spock, ChoiceType.Scissors),
        new Rule(ChoiceType.Spock, ChoiceType.Rock)
    };

    public static RoundOutcome DetermineOutcome(ChoiceType playerChoice, ChoiceType computerChoice)
    {
        if (playerChoice == computerChoice)
        {
            return RoundOutcome.Tie;
        }

        return Rules.Any(rule => rule.Winner == playerChoice && rule.Loser == computerChoice) 
            ? RoundOutcome.Win 
            : RoundOutcome.Lose;
    }
}