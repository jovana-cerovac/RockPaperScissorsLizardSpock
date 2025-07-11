using GameAPI.Core.Contracts;
using GameAPI.Core.Domain;
using GameAPI.Core.Services.Abstractions;

namespace GameAPI.Core.Services;

public class PlayService(
    IChoicesApiClient choicesApiClient,
    IGameRoundService gameRoundService,
    IRulesService rulesService,
    IChoiceValidator choiceValidator) : IPlayService
{
    public async Task<PlayResponse> PlayRoundAsync(PlayRequest playRequest)
    {
        choiceValidator.ValidateChoiceId(playRequest.Player);

        var playerChoice = await choicesApiClient.GetChoiceByIdAsync(playRequest.Player);
        var computerChoice = await choicesApiClient.GetRandomChoiceAsync();

        var playerChoiceType = MapToChoiceType(playerChoice);
        var computerChoiceType = MapToChoiceType(computerChoice);

        var outcome = rulesService.DetermineOutcome(playerChoiceType, computerChoiceType);

        AddNewGameRound(outcome, playerChoice, computerChoice);

        return new PlayResponse(
            results: outcome.ToString(),
            player: playerChoice.Id,
            computer: computerChoice.Id
        );
    }

    private void AddNewGameRound(RoundOutcome outcome, ChoiceResponse playerChoice, ChoiceResponse computerChoice)
    {
        var gameRound = new GameRound(
            Guid.NewGuid(),
            playerChoice.Id,
            computerChoice.Id,
            outcome,
            DateTimeOffset.UtcNow);

        gameRoundService.AddRoundAsync(gameRound);
    }

    private ChoiceType MapToChoiceType(ChoiceResponse choiceResponse)
    {
        choiceValidator.ValidateChoiceId(choiceResponse.Id);
        return (ChoiceType)choiceResponse.Id;
    }
}