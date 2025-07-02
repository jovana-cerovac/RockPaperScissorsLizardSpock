using ChoiceAPI.Core.Contracts;

namespace ChoiceAPI.Core.Services.Abstractions;

public interface IChoiceService
{
    IEnumerable<ChoiceResponse> GetAll();

    Task<ChoiceResponse> GetRandomAsync();

    ChoiceResponse GetById(int id);
}