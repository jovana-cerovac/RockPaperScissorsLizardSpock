using GameAPI.Core.Domain;

namespace GameAPI.Core.Services.Abstractions;

public interface IRulesService
{
    RoundOutcome DetermineOutcome(ChoiceType playerChoice, ChoiceType computerChoice);
}