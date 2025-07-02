using GameAPI.Core.Contracts;

namespace GameAPI.Core.Services.Abstractions;

public interface IGameService
{
    Task<PlayResponse> PlayRoundAsync(PlayRequest playRequest);
}