using ChoiceAPI.Core.Contracts;
using ChoiceAPI.Core.Exceptions;
using ChoiceAPI.Core.Persistence;
using ChoiceAPI.Core.Services.Abstractions;

namespace ChoiceAPI.Core.Services;

public class ChoiceService(IChoiceRepository repository, IRandomNumberService randomNumberService) : IChoiceService
{
    private const int MinChoiceId = 1;
    private const int MaxChoiceId = 5;
    
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
            : throw new NotFoundException($"Choice with ID {choiceId} not found.");
    }

    public ChoiceResponse GetById(int id)
    {
        if (id is < MinChoiceId or > MaxChoiceId)
        {
            throw new BadRequestException($"Choice ID must be between {MinChoiceId} and {MaxChoiceId}.");
        }
        
        var choice = repository.GetById(id);
        return choice is not null
            ? ChoiceResponse.FromDomain(choice)
            : throw new NotFoundException($"Choice with ID {id} not found.");
    }

    private static int EvaluateChoiceId(int randomNumber, int totalCountOfChoices) =>
        randomNumber % totalCountOfChoices + 1;
}