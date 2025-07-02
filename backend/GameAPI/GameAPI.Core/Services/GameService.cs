using GameAPI.Core.Contracts;
using GameAPI.Core.Services.Abstractions;

namespace GameAPI.Core.Services;

public class GameService(IChoiceService choiceService) : IGameService
{
    public async Task<PlayResponse> PlayRoundAsync(PlayRequest playRequest)
    {
        var choice1 = await choiceService.GetChoiceByIdAsync(1);

        return new PlayResponse("win/lose/tie", 1, 2);
    }
}