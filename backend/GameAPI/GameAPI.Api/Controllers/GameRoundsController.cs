using GameAPI.Core.Contracts;
using GameAPI.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameRoundsController(IGameRoundService gameRoundService) : ControllerBase
{
    /// <summary>
    /// Retrieves the latest game rounds.
    /// </summary>
    /// <param name="count">The number of most recent rounds to return. Default is 10.</param>
    /// <response code="200">Latest game rounds retrieved successfully.</response>
    /// <response code="404">No game rounds found.</response>
    /// <response code="500">Something went wrong while retrieving game rounds.</response>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains
    /// a list of <see cref="GameRoundResponse"/> representing the recent rounds.
    /// </returns>
    [HttpGet]
    [ActionName(nameof(GetLatestRoundsAsync))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GameRoundResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<GameRoundResponse>>> GetLatestRoundsAsync([FromQuery]int count = 10)
    {
        var gameRounds = await gameRoundService.GetLatestRoundsAsync(count);
        return Ok(gameRounds);
    }
    
    /// <summary>
    /// Removes all recorded game rounds.
    /// </summary>
    /// <response code="204">All game rounds successfully removed.</response>
    /// <response code="500">Something went wrong while removing the game rounds.</response>
    /// <returns>
    /// A task representing the asynchronous operation. The task result indicates
    /// completion with no content.
    /// </returns>

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RemoveAllRoundsAsync()
    {
        await gameRoundService.RemoveAllRoundsAsync();
        return NoContent();
    }
}