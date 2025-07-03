using GameAPI.Core.Contracts;
using GameAPI.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameRoundsController(IGameRoundService gameRoundService) : ControllerBase
{
    [HttpGet("game-rounds")]
    [ActionName(nameof(GetLatestRoundsAsync))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GameRoundResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<GameRoundResponse>>> GetLatestRoundsAsync([FromQuery]int count = 10)
    {
        var gameRounds = await gameRoundService.GetLatestRoundsAsync(count);
        return Ok(gameRounds);
    }
    
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RemoveAllRoundsAsync()
    {
        await gameRoundService.RemoveAllRoundsAsync();
        return NoContent();
    }
}