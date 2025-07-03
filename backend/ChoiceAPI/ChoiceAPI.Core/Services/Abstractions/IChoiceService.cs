using ChoiceAPI.Core.Contracts;

namespace ChoiceAPI.Core.Services.Abstractions;

public interface IChoiceService
{
    Task<IEnumerable<ChoiceResponse>> GetAllChoicesAsync();

    Task<ChoiceResponse> GetRandomChoiceAsync();

    Task<ChoiceResponse> GetChoiceByIdAsync(int id);
}