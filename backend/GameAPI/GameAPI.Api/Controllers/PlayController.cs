using GameAPI.Core.Contracts;
using GameAPI.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayController(IPlayService playService) : ControllerBase
{
    /// <summary>
    /// Plays a single round of the game based on the player's choice.
    /// </summary>
    /// <param name="request">The player's choice ID.</param>
    /// <response code="200">Game round played successfully.</response>
    /// <response code="400">The request is invalid or contains an unsupported choice ID.</response>
    /// <response code="500">Something went wrong during the game logic execution.</response>
    /// <response code="502">Choices service is unavailable while retrieving a choice.</response>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains
    /// a <see cref="PlayResponse"/> indicating the outcome of the round.
    /// </returns>
    [HttpPost]
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