using GameAPI.Core.Domain;

namespace GameAPI.Core.Contracts;

public class GameRoundResponse
{
    public string Id { get; }

    public int PlayerChoiceId { get; }

    public int ComputerChoiceId { get; }

    public RoundOutcome Outcome { get; }

    public DateTimeOffset PlayedAt { get; }
    
    private GameRoundResponse(string id, int playerChoiceId, int computerChoiceId, RoundOutcome outcome, DateTimeOffset playedAt)
    {
        Id = id;
        PlayerChoiceId = playerChoiceId;
        ComputerChoiceId = computerChoiceId;
        Outcome = outcome;
        PlayedAt = playedAt;
    }

    public static GameRoundResponse FromDomain(GameRound gameRound)
    {
        return new GameRoundResponse(
            gameRound.Id.ToString(),
            gameRound.PlayerChoiceId,
            gameRound.ComputerChoiceId,
            gameRound.Outcome,
            gameRound.PlayedAt);
    }
}