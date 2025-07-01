using ChoiceAPI.Core.Contracts;
using ChoiceAPI.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ChoiceAPI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChoicesController(IChoiceService choiceService) : ControllerBase
{
    [HttpGet]
    [ActionName(nameof(GetAllChoices))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ChoiceResponse>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<IEnumerable<ChoiceResponse>> GetAllChoices()
    {
        var choices = choiceService.GetAll();
        return Ok(choices);
    }

    [HttpGet("random")]
    [ActionName(nameof(GetRandomChoiceAsync))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChoiceResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ChoiceResponse>> GetRandomChoiceAsync()
    {
        var choice = await choiceService.GetRandomAsync();
        return Ok(choice);
    }
}