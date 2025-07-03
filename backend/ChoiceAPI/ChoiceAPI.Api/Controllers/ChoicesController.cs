using ChoiceAPI.Core.Contracts;
using ChoiceAPI.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ChoiceAPI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChoicesController(IChoiceService choiceService) : ControllerBase
{
    [HttpGet("choices")]
    [ActionName(nameof(GetAllChoicesAsync))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ChoiceResponse>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<ChoiceResponse>>> GetAllChoicesAsync()
    {
        var choices = await choiceService.GetAllChoicesAsync();
        return Ok(choices);
    }

    [HttpGet("choice")]
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
    
    [HttpGet("{id}")]
    [ActionName(nameof(GetRandomChoiceAsync))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChoiceResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ChoiceResponse>> GetChoiceByIdAsync([FromRoute]int id)
    {
        var choice = await choiceService.GetChoiceByIdAsync(id);
        return Ok(choice);
    }
}