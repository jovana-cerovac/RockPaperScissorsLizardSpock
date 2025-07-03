using GameAPI.Core.Domain;
using GameAPI.Core.Exceptions;
using GameAPI.Core.Persistence;
using GameAPI.Core.Services.Abstractions;

namespace GameAPI.Core.Services;

public class GameRoundService(IGameRoundRepository repository) : IGameRoundService
{
    public async Task AddRoundAsync(GameRound gameRound) =>
        await repository.AddAsync(gameRound);

    public async Task RemoveAllRoundsAsync() =>
        await repository.RemoveAllAsync();

    public async Task<IReadOnlyList<GameRound>> GetLatestRoundsAsync(int count)
    {
        if (count <= 0)
        {
            throw new BadRequestException($"Invalid Count {count}. Count must be greater than zero.");
        }

        return await repository.GetLatestRoundsAsync(count);
    }
}