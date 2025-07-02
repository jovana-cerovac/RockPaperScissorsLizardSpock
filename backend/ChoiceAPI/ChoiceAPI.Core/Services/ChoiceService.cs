using ChoiceAPI.Core.Contracts;
using ChoiceAPI.Core.Persistence;
using ChoiceAPI.Core.Services.Abstractions;

namespace ChoiceAPI.Core.Services;

public class ChoiceService(IChoiceRepository repository, IRandomNumberService randomNumberService) : IChoiceService
{
    public IEnumerable<ChoiceResponse> GetAll()
    {
        return repository.GetAllChoices().Select(ChoiceResponse.FromDomain);
    }

    public async Task<ChoiceResponse> GetRandomAsync()
    {
        var randomNumber = await randomNumberService.GetRandomNumberAsync();
        var totalCountOfChoices = repository.GetTotalCount();
        var choiceId = EvaluateChoiceId(randomNumber, totalCountOfChoices);
        var randomChoice = repository.GetById(choiceId);

        return randomChoice is not null
            ? ChoiceResponse.FromDomain(randomChoice)
            : throw new Exception(); // TODO: Custom exception and global handling
    }

    public ChoiceResponse GetById(int id)
    {
        var choice = repository.GetById(id);
        return choice is not null
            ? ChoiceResponse.FromDomain(choice)
            : throw new Exception(); // TODO: Custom exception and global handling
    }

    private static int EvaluateChoiceId(int randomNumber, int totalCountOfChoices) =>
        randomNumber % totalCountOfChoices + 1;
}