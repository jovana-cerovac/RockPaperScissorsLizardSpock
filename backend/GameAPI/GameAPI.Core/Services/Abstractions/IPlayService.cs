using GameAPI.Core.Contracts;

namespace GameAPI.Core.Services.Abstractions;

public interface IPlayService
{
    Task<PlayResponse> PlayRoundAsync(PlayRequest playRequest);
}