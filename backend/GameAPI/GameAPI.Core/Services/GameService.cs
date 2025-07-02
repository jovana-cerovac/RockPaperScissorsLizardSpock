using GameAPI.Core.Contracts;
using GameAPI.Core.Domain;
using GameAPI.Core.Exceptions;
using GameAPI.Core.Services.Abstractions;

namespace GameAPI.Core.Services;

public class GameService(IChoicesApiClient choicesApiClient) : IGameService
{
    private const int MinChoiceId = 1;
    private const int MaxChoiceId = 5;

    public async Task<PlayResponse> PlayRoundAsync(PlayRequest playRequest)
    {
        ValidateChoiceId(playRequest.Player);

        var playerChoice = await choicesApiClient.GetChoiceByIdAsync(playRequest.Player);
        var computerChoice = await choicesApiClient.GetRandomChoiceAsync();

        var playerChoiceType = MapToChoiceType(playerChoice);
        var computerChoiceType = MapToChoiceType(computerChoice);

        var outcome = GameRules.DetermineOutcome(playerChoiceType, computerChoiceType);

        return new PlayResponse(
            results: outcome.ToString(),
            player: playerChoice.Id,
            computer: computerChoice.Id
        );
    }
    
    private static void ValidateChoiceId(int choiceId)
    {
        if (!Enum.IsDefined(typeof(ChoiceType), choiceId))
        {
            throw new BadRequestException(
                $"Invalid Choice ID value {choiceId}. Choice ID must be between {MinChoiceId} and {MaxChoiceId}.");
        }
    }

    private static ChoiceType MapToChoiceType(ChoiceResponse choiceResponse)
    {
        ValidateChoiceId(choiceResponse.Id);
        return (ChoiceType)choiceResponse.Id;
    }
}