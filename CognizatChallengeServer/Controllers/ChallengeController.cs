using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CognizatChallengeServer.Controllers
{
    [ApiController]
    [Route("api/attempts")]
    public class ChallengeController : BaseController
    {
        private readonly IChallengeService _service;

        public ChallengeController(IChallengeService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ObjectResult> SaveAttempt(AttemptRequest attempt)
        {
            var result = await _service.SaveAttempt(attempt);
            return OkJson(result);
        }

        [HttpGet("leader")]
        public async Task<ObjectResult> GetLeaderboard()
        {
            var result = await _service.GetLeaderBoard();
            return OkJson(result);
        }
    }
}
