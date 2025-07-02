using ChoiceAPI.Core.Contracts;
using ChoiceAPI.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ChoiceAPI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChoicesController(IChoiceService choiceService) : ControllerBase
{
    [HttpGet("choices")]
    [ActionName(nameof(GetAllChoices))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ChoiceResponse>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<IEnumerable<ChoiceResponse>> GetAllChoices()
    {
        var choices = choiceService.GetAll();
        return Ok(choices);
    }

    [HttpGet("choice")]
    [ActionName(nameof(GetRandomChoiceAsync))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChoiceResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ChoiceResponse>> GetRandomChoiceAsync()
    {
        var choice = await choiceService.GetRandomAsync();
        return Ok(choice);
    }
    
    [HttpGet("{id}")]
    [ActionName(nameof(GetRandomChoiceAsync))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChoiceResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<ChoiceResponse> GetChoiceById([FromRoute]int id)
    {
        var choice = choiceService.GetById(id);
        return Ok(choice);
    }
}