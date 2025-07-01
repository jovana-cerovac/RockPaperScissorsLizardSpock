using ChoiceAPI.Core.Contracts;
using ChoiceAPI.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChoiceAPI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChoicesController : ControllerBase
{
    private readonly IChoiceService _choiceService;
    
    public ChoicesController(IChoiceService choiceService)
    {
        _choiceService = choiceService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ChoiceResponse>> GetAllChoices()
    {
        var choices = _choiceService.GetAll();
        return Ok(choices);
    }

    [HttpGet("random")]
    public ActionResult<ChoiceResponse> GetRandomChoice()
    {
        var choice = _choiceService.GetRandom();
        return Ok(choice);
    }
}