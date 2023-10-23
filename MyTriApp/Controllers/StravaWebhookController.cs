using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTriApp.Data.Entities;
using MyTriApp.Secrets;
using MyTriApp.Services.Interfaces;
using MyTriApp.Strava_API;

namespace MyTriApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StravaWebhookController : ControllerBase
    {

        public StravaWebhookController()
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetSubcriptionValidation([FromQuery(Name ="hub.mode")] string mode, [FromQuery(Name = "hub.challenge")] string challenge, [FromQuery(Name ="hub.verify_token")] string verify_token)
        {
            if (mode == "subscribe" && verify_token == "STRAVAWEBHOOK")
            {
                return Ok($"{{ \"hub.challenge\" : \"{challenge}\"}}");
            }
            return BadRequest();
        }

    }
}
