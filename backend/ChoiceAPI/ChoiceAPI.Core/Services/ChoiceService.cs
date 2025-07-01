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
        var maybeRandomChoice = repository.GetById(choiceId);

        return maybeRandomChoice is not null
            ? ChoiceResponse.FromDomain(maybeRandomChoice)
            : throw new Exception(); // TODO: Custom exception and global handling
    }

    private static int EvaluateChoiceId(int randomNumber, int totalCountOfChoices) =>
        randomNumber % totalCountOfChoices + 1;
}