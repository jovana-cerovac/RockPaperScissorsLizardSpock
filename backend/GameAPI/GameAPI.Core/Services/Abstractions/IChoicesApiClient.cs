using GameAPI.Core.Contracts;

namespace GameAPI.Core.Services.Abstractions;

public interface IChoicesApiClient
{
    Task<ChoiceResponse> GetChoiceByIdAsync(int id);

    Task<ChoiceResponse> GetRandomChoiceAsync();
}