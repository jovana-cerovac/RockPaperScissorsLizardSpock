using GameAPI.Core.Contracts;
using GameAPI.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController(IGameService gameService) : ControllerBase
{
    [HttpPost("play")]
    [ActionName(nameof(PlayRound))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlayResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PlayRound([FromBody] PlayRequest request)
    {
        //TODO: Dodati proveru u servisu => ako ChoiceAPI vrati gresku, onda vratiti bad request
        // if (request == null || request.Player <= 0)
        // {
        //     return BadRequest("Invalid player choice.");
        // }

        var result = await gameService.PlayRoundAsync(request);

        return Ok(result);
    }
}