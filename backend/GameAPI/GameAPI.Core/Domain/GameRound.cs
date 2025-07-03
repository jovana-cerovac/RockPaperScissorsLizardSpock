namespace GameAPI.Core.Domain;

public class GameRound(Guid id, int playerChoiceId, int computerChoiceId, RoundOutcome outcome, DateTimeOffset playedAt)
{
    public Guid Id { get; } = id;

    public int PlayerChoiceId { get; } = playerChoiceId;

    public int ComputerChoiceId { get; } = computerChoiceId;

    public RoundOutcome Outcome { get; } = outcome;

    public DateTimeOffset PlayedAt { get; } = playedAt;
}