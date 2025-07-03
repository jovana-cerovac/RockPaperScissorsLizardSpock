namespace GameAPI.Core.Domain;

public static class RulesProvider
{
    public static IReadOnlyList<Rule> GetStandardRules() => new List<Rule>
    {
        new(ChoiceType.Rock, ChoiceType.Scissors),
        new(ChoiceType.Rock, ChoiceType.Lizard),
        new(ChoiceType.Paper, ChoiceType.Rock),
        new(ChoiceType.Paper, ChoiceType.Spock),
        new(ChoiceType.Scissors, ChoiceType.Paper),
        new(ChoiceType.Scissors, ChoiceType.Lizard),
        new(ChoiceType.Lizard, ChoiceType.Spock),
        new(ChoiceType.Lizard, ChoiceType.Paper),
        new(ChoiceType.Spock, ChoiceType.Scissors),
        new(ChoiceType.Spock, ChoiceType.Rock)
    };
}