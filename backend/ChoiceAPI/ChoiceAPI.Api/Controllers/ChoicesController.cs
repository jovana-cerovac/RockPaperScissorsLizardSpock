using ChoiceAPI.Core.Contracts;
using ChoiceAPI.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ChoiceAPI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChoicesController(IChoiceService choiceService) : ControllerBase
{
    /// <summary>
    /// Retrieves all available choices.
    /// </summary>
    /// <response code="200">Choices retrieved successfully.</response>
    /// <response code="500">Something went wrong.</response>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains
    /// an action result with a collection of <see cref="ChoiceResponse"/>.
    /// </returns>
    [HttpGet("")]
    [ActionName(nameof(GetAllChoicesAsync))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ChoiceResponse>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<ChoiceResponse>>> GetAllChoicesAsync()
    {
        var choices = await choiceService.GetAllChoicesAsync();
        return Ok(choices);
    }

    /// <summary>
    /// Retrieves a random choice from the available choices.
    /// </summary>
    /// <response code="200">Random choice retrieved successfully.</response>
    /// <response code="404">Random choice not found.</response>
    /// <response code="500">Something went wrong.</response>
    /// <response code="502">Random service not available while retrieving the choice.</response>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains
    /// an action result with a single <see cref="ChoiceResponse"/> object.
    /// </returns>
    [HttpGet("random-choice")]
    [ActionName(nameof(GetRandomChoiceAsync))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChoiceResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status502BadGateway)]
    public async Task<ActionResult<ChoiceResponse>> GetRandomChoiceAsync()
    {
        var choice = await choiceService.GetRandomChoiceAsync();
        return Ok(choice);
    }

    /// <summary>
    /// Retrieves a choice by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the choice to retrieve.</param>
    /// <response code="200">Choice retrieved successfully.</response>
    /// <response code="400">Invalid request. The provided ID is invalid.</response>
    /// <response code="404">Choice not found with the specified ID.</response>
    /// <response code="500">Something went wrong.</response>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains
    /// an action result with a <see cref="ChoiceResponse"/> object.
    /// </returns>
    [HttpGet("{id:int}")]
    [ActionName(nameof(GetRandomChoiceAsync))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChoiceResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ChoiceResponse>> GetChoiceByIdAsync([FromRoute] int id)
    {
        var choice = await choiceService.GetChoiceByIdAsync(id);
        return Ok(choice);
    }
}