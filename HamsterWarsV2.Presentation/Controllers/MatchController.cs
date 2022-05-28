using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.Match;

namespace HamsterWarsV2.Presentation.Controllers;

[Route("api/[controller]")]
public class MatchController : ControllerBase
{
    private readonly IServiceManager _service;

    public MatchController(IServiceManager service) => _service = service;

    [HttpGet]
    [Route("/matches")]
    public IActionResult GetMatches()
    {
        var matches = _service.MatchService.GetMatches(trackChanges: false);
        return Ok(matches);
    }

    [HttpGet]
    [Route("/matches/{id}")]
    public IActionResult GetMatch(int id)
    {
        var match = _service.MatchService.GetMatch(id, trackChanges: false);
        return Ok(match);
    }

    [HttpPost]
    [Route("/matches")]
    public IActionResult CreateMatch([FromBody] MatchForCreationDto match)
    {
        if (match is null)
        {
            return BadRequest("MatchForCreationDto object is null");
        }

        var matchToReturn = _service.MatchService.CreateMatch(match, trackChanges: false);

        return CreatedAtRoute(new { id = matchToReturn.Id }, matchToReturn);
    }

    [HttpDelete]
    [Route("/matches/{id}")]
    public IActionResult DeleteMatch(int id)
    {
        _service.MatchService.DeleteMatch(id, trackChanges: false);
        return NoContent();
    }
}
