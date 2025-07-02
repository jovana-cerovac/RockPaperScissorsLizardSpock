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
    [ProducesResponseType(StatusCodes.Status502BadGateway)]
    public async Task<IActionResult> PlayRound([FromBody] PlayRequest request)
    {
        var playResponse = await gameService.PlayRoundAsync(request);
        return Ok(playResponse);
    }
}