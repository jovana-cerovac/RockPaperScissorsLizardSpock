using GameAPI.Core.Contracts;
using GameAPI.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayController(IPlayService playService) : ControllerBase
{
    [HttpPost("play")]
    [ActionName(nameof(PlayRoundAsync))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlayResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status502BadGateway)]
    public async Task<IActionResult> PlayRoundAsync([FromBody] PlayRequest request)
    {
        var playResponse = await playService.PlayRoundAsync(request);
        return Ok(playResponse);
    }
}