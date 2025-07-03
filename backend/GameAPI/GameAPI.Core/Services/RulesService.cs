using GameAPI.Core.Domain;
using GameAPI.Core.Services.Abstractions;

namespace GameAPI.Core.Services;

public class RulesService : IRulesService
{
    private readonly IReadOnlyList<Rule> _rules = RulesProvider.GetStandardRules();

    public RoundOutcome DetermineOutcome(ChoiceType playerChoice, ChoiceType computerChoice)
    {
        if (playerChoice == computerChoice)
        {
            return RoundOutcome.Tie;
        }

        return _rules.Any(rule => rule.Winner == playerChoice && rule.Loser == computerChoice) 
            ? RoundOutcome.Win 
            : RoundOutcome.Lose;
    }
}