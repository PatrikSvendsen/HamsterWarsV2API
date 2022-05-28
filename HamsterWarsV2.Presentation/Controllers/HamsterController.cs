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
    public IActionResult GetHamsters()
    {
        var hamsters = _service.HamsterService.GetAllHamsters(trackChanges: false);
        return Ok(hamsters);
    }
    [HttpGet]
    [Route("/hamsters/random")]
    public IActionResult GetRandomHamster()
    {
        var hamster = _service.HamsterService.GetRandomHamster(trackChanges: false);
        return Ok(hamster);
    }

    [HttpGet]
    [Route("/hamsters/{id:int}", Name = "HamsterById")]
    public IActionResult GetHamster(int id)
    {
        var hamster = _service.HamsterService.GetHamster(id, trackChanges: false);
        return Ok(hamster);
    }

    [HttpPost]
    [Route("/hamsters")]
    public IActionResult CreateHamster([FromBody] HamsterForCreationDto hamster)
    {
        if (hamster is null)
        {
            return BadRequest("HamsterForCreationDto object is null");
        }

        var createdHamster = _service.HamsterService.CreateHamster(hamster);

        return CreatedAtRoute("HamsterById", new { id = createdHamster.Id }, createdHamster);
    }

    [HttpDelete]
    [Route("/hamsters/{id:int}")]
    public IActionResult DeleteHamster(int id)
    {
        _service.HamsterService.DeleteHamster(id, trackChanges: false);
        return NoContent();
    }

    [HttpPut]
    [Route("/hamsters/{id:int}")]
    public IActionResult UpdateHamster(int id, [FromBody] HamsterToUpdateDto hamster)
    {
        if (hamster is null)
        {
            return BadRequest("HamsterToUpdateDto object is null");
        }

        _service.HamsterService.UpdateHamster(id, hamster, trackChanges: true);

        return NoContent();
    }
}
