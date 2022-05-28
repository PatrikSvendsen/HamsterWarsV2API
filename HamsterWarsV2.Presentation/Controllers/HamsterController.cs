using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace HamsterWarsV2.Presentation.Controllers // Gillar inte File-scope i controllern
{
    [Route("api/hamsters")]
    [ApiController]
    public class HamsterController : ControllerBase
    {
        private readonly IServiceManager _service;
        public HamsterController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetHamsters()
        {
            var hamsters = _service.HamsterService.GetAllHamsters(trackChanges: false);
            return Ok(hamsters);
        }

        [HttpGet("id:int")]
        public IActionResult GetHamster(int id)
        {
            var hamster = _service.HamsterService.GetHamster(id, trackChanges: false);
            return Ok(hamster);
        }
    }
}
