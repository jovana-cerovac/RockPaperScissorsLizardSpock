using GameAPI.Core.Domain;
using GameAPI.Core.Persistence;

namespace GameAPI.Infrastructure.Persistence;

public class GameRoundRepository : IGameRoundRepository
{
    private static List<GameRound> _gameRounds = new();

    public Task AddAsync(GameRound gameRound)
    {
        _gameRounds.Add(gameRound);
        return Task.CompletedTask;
    }

    public Task RemoveAllAsync()
    {
        _gameRounds = new List<GameRound>();
        return Task.CompletedTask;
    }

    public Task<IReadOnlyList<GameRound>> GetLatestRoundsAsync(int count)
    {
        var latestRounds = _gameRounds
            .OrderByDescending(round => round.PlayedAt)
            .Take(count)
            .ToList();

        return Task.FromResult<IReadOnlyList<GameRound>>(latestRounds);
    }
}