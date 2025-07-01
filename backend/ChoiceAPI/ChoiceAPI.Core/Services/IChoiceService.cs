using ChoiceAPI.Core.Contracts;

namespace ChoiceAPI.Core.Services;

public interface IChoiceService
{
    IEnumerable<ChoiceResponse> GetAll();

    ChoiceResponse GetRandom();
}