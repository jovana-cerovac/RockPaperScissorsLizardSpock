using GameAPI.Core.Domain;

namespace GameAPI.Core.Services.Abstractions;

public interface IGameRoundService
{
    Task AddRoundAsync(GameRound gameRound);

    Task RemoveAllRoundsAsync();

    Task<IReadOnlyList<GameRound>> GetLatestRoundsAsync(int count);
}