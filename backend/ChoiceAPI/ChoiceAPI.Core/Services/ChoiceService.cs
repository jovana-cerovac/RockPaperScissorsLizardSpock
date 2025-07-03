using ChoiceAPI.Core.Constants;
using ChoiceAPI.Core.Contracts;
using ChoiceAPI.Core.Exceptions;
using ChoiceAPI.Core.Persistence;
using ChoiceAPI.Core.Services.Abstractions;

namespace ChoiceAPI.Core.Services;

public class ChoiceService(IChoiceRepository repository, IRandomNumberService randomNumberService) : IChoiceService
{
    public async Task<IEnumerable<ChoiceResponse>> GetAllChoicesAsync()
    {
        var allChoices = await repository.GetAllChoicesAsync();
        return allChoices.Select(ChoiceResponse.FromDomain);
    }

    public async Task<ChoiceResponse> GetRandomChoiceAsync()
    {
        var randomNumber = await randomNumberService.GetRandomNumberAsync();
        var totalCountOfChoices = await repository.GetTotalCountAsync();
        var choiceId = EvaluateChoiceId(randomNumber, totalCountOfChoices);
        var randomChoice = await repository.GetByIdAsync(choiceId);

        return randomChoice is not null
            ? ChoiceResponse.FromDomain(randomChoice)
            : throw new NotFoundException($"Choice with ID {choiceId} not found.");
    }

    public async Task<ChoiceResponse> GetChoiceByIdAsync(int id)
    {
        if (id is < ChoiceConstants.MinChoiceId or > ChoiceConstants.MaxChoiceId)
        {
            throw new BadRequestException(
                $"Invalid Choice ID {id}. Choice ID must be between {ChoiceConstants.MinChoiceId} and {ChoiceConstants.MaxChoiceId}.");
        }

        var choice = await repository.GetByIdAsync(id);
        return choice is not null
            ? ChoiceResponse.FromDomain(choice)
            : throw new NotFoundException($"Choice with ID {id} not found.");
    }

    private static int EvaluateChoiceId(int randomNumber, int totalCountOfChoices) =>
        randomNumber % totalCountOfChoices + 1;
}