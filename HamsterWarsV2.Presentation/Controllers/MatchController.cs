using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace HamsterWarsV2.Presentation.Controllers
{
    [Route("api/matches")]
    public class MatchController : ControllerBase
    {
        private readonly IServiceManager _service;

        public MatchController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetMatches()
        {
            var matches = _service.MatchService.GetMatches(trackChanges: false);
            return Ok(matches);
        }

        [HttpGet("{matchId}")]
        public IActionResult GetMatch(int matchId)
        {
            var match = _service.MatchService.GetMatch(matchId, trackChanges: false);
            return Ok(match);
        }
    }
}
