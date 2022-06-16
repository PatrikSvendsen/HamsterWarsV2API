using Microsoft.AspNetCore.Authorization;
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
    public async Task<IActionResult> GetMatches()
    {
        var matches = 
            await _service.MatchService.GetMatchesAsync(trackChanges: false);
        return Ok(matches);
    }

    [HttpGet]
    [Route("/matches/{id}")]
    public async Task<IActionResult> GetMatch(int id)
    {
        var match =
            await _service.MatchService.GetMatchAsync(id, trackChanges: false);
        return Ok(match);
    }

    [HttpGet]
    [Route("/matchWinners/{hamsterId}")]
    public async Task<IActionResult> GetHamsterMatches(int hamsterId)
    {
        var hamsterMatches = 
            await _service.MatchService.GetAllHamsterMatchesAsync(hamsterId, trackChanges: false);
        return Ok(hamsterMatches);
    }

    [HttpPost]
    [Route("/matches")]
    public async Task<IActionResult> CreateMatch([FromBody] MatchForCreationDto match)
    {
        if (match is null)
        {
            return BadRequest("MatchForCreationDto object is null");
        }
        if (ModelState.IsValid == false)
        {
            return UnprocessableEntity(ModelState);
        }

        var matchToReturn = 
            await _service.MatchService.CreateMatchAsync(match, trackChanges: false);

        return CreatedAtRoute(new { id = matchToReturn.Id }, matchToReturn);
    }

    [HttpDelete, Authorize(Roles = "Admin")]
    [Route("/matches/{id}")]
    public async Task<IActionResult> DeleteMatch(int id)
    {
        await _service.MatchService.DeleteMatchAsync(id, trackChanges: false);
        return NoContent();
    }
}
