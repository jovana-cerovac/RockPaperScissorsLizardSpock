namespace GameAPI.Core.Domain;

public class Rule(ChoiceType winner, ChoiceType loser)
{
    public ChoiceType Winner { get; } = winner;
    public ChoiceType Loser { get; } = loser;
}