using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.Hamster;

namespace HamsterWarsV2.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HamsterController : ControllerBase
{
    private readonly IServiceManager _service;
    public HamsterController(IServiceManager service) => _service = service;

    [HttpGet]
    [Route("/hamsters")]
    public async Task<IActionResult> GetHamsters()
    {
        var hamsters = 
            await _service.HamsterService.GetAllHamstersAsync(trackChanges: false);
        return Ok(hamsters);
    }

    [HttpGet]
    [Route("/hamsters/random")]
    public async Task<IActionResult> GetRandomHamster()
    {
        var hamster = 
            await _service.HamsterService.GetRandomHamsterAsync(trackChanges: false);
        return Ok(hamster);
    }

    [HttpGet]
    [Route("/hamsters/randoms")]
    public async Task<IActionResult> Get2RandomHamsters()
    {
        var hamsters =
            await _service.HamsterService.Get2RandomHamsterAsync(trackChanges: false);
        return Ok(hamsters);
    }

    [HttpGet]
    [Route("/hamsters/{id:int}", Name = "HamsterById")]
    public async Task<IActionResult> GetHamster(int id)
    {
        var hamster = 
            await _service.HamsterService.GetHamsterAsync(id, trackChanges: false);
        return Ok(hamster);
    }

    [HttpGet]
    [Route("/winners")]
    public async Task<IActionResult> GetTop5Hamsters()
    {
        var hamsters =
            await _service.HamsterService.GetTop5HamstersAsync(trackChanges: false);
        return Ok(hamsters);
    }

    [HttpGet]
    [Route("/losers")]
    public async Task<IActionResult> GetBot5Hamsters()
    {
        var hamsters = 
            await _service.HamsterService.GetBot5HamstersAsync(trackChanges: false);
        return Ok(hamsters);
    }

    [HttpPost]
    [Route("/hamsters")]
    public async Task<IActionResult> CreateHamster([FromBody] HamsterForCreationDto hamster)
    {
        if (hamster is null)
        {
            return BadRequest("HamsterForCreationDto object is null");
        }
        if (ModelState.IsValid == false)
        {
            return UnprocessableEntity(ModelState);
        }

        var createdHamster = 
            await _service.HamsterService.CreateHamsterAsync(hamster);

        return CreatedAtRoute("HamsterById", new { id = createdHamster.Id }, createdHamster);
    }

    [HttpDelete]
    [Route("/hamsters/{id:int}")]
    public async Task<IActionResult> DeleteHamster(int id)
    {
        await _service.HamsterService.DeleteHamsterAsync(id, trackChanges: false);
        return NoContent();
    }

    [HttpPut]
    [Route("/hamsters/{id:int}")]
    public async Task<IActionResult> UpdateHamster(int id, [FromBody] HamsterToUpdateDto hamster)
    {
        if (hamster is null)
        {
            return BadRequest("HamsterToUpdateDto object is null");
        }

        await _service.HamsterService.UpdateHamsterAsync(id, hamster, trackChanges: true);
        
        return Ok(hamster);
    }
}
