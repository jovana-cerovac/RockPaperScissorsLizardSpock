using ChoiceAPI.Core.Contracts;
using ChoiceAPI.Core.Persistence;

namespace ChoiceAPI.Core.Services;

public class ChoiceService : IChoiceService
{
    // TODO: Change random function!
    private readonly Random _random = new();
    private readonly IChoiceRepository _repository;

    public ChoiceService(IChoiceRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<ChoiceResponse> GetAll()
    {
        return _repository.GetAllChoices().Select(ChoiceResponse.FromDomain);
    }

    public ChoiceResponse GetRandom()
    {
        var choices = _repository.GetAllChoices().ToList();
        var index = _random.Next(choices.Count);
        return ChoiceResponse.FromDomain(choices[index]);
    }
}