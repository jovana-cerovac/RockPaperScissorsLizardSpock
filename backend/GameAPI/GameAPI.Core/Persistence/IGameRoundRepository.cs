using GameAPI.Core.Domain;

namespace GameAPI.Core.Persistence;

public interface IGameRoundRepository
{
    Task AddAsync(GameRound gameRound);

    Task RemoveAllAsync();

    Task<IReadOnlyList<GameRound>> GetLatestRoundsAsync(int count);
}