using Microsoft.AspNetCore.Mvc;
using MyTriApp.Data.Entities;
using MyTriApp.DTO;
using MyTriApp.Services.Interfaces;
using MyTriApp.Strava_API;

namespace MyTriApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StravaWebhookController : ControllerBase
    {
        private IStravaAccessTokenService _stravaAccessTokenService;
        private IActivityService _activityService;
        private IStravaAPI _stravaAPI;

        public StravaWebhookController(IStravaAccessTokenService stravaAccessTokenService, IActivityService activityService, IStravaAPI stravaAPI)
        {
            _stravaAccessTokenService = stravaAccessTokenService;
            _activityService = activityService;
            _stravaAPI = stravaAPI;
        }

        [HttpGet]
        public IActionResult GetSubcriptionValidation([FromQuery(Name ="hub.mode")] string mode, [FromQuery(Name = "hub.challenge")] string challenge, [FromQuery(Name ="hub.verify_token")] string verify_token)
        {
            if (mode == "subscribe" && verify_token == "STRAVAWEBHOOK")
            {
                return Ok($"{{ \"hub.challenge\" : \"{challenge}\"}}");
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> PostEvent([FromBody] StravaEvent stravaEvent)
        {
            if(stravaEvent.object_type == "athlete")
            {
                return await HandleAthleteEvent(stravaEvent);
            }
            else
            {
                return await HandleActivityEvent(stravaEvent);
            }
        }

        private async Task<IActionResult> HandleActivityEvent(StravaEvent stravaEvent)
        {
            switch (stravaEvent.aspect_type)
            {
                case "create":
                    //get stravaAccessToken
                    var stravaAccessToken = await _stravaAccessTokenService.GetStravaAccessToken(stravaEvent.owner_id);
                    if (stravaAccessToken == null)
                    {
                        return BadRequest();
                    }
                    if (DateTimeOffset.FromUnixTimeSeconds(stravaAccessToken.ExpiresAt).DateTime < DateTime.Now)
                    {
                        var accessTokenDTO = await _stravaAPI.RefreshStravaAccessToken(stravaAccessToken);
                        stravaAccessToken = StravaAccessToken.From(accessTokenDTO, stravaAccessToken.UserId);
                        await _stravaAccessTokenService.UpdateStravaAccessToken(stravaAccessToken);
                    }
                    //retrieve activity from strava api
                    var activity = await _stravaAPI.GetActivityById(stravaAccessToken, stravaEvent.object_id);
                    //store activity in our db
                    if (activity == null)
                    {
                        return BadRequest();
                    }
                    else
                    {
                        var createResult = await _activityService.CreateActivity(activity.ToActivity(stravaAccessToken.UserId));
                        return createResult ? Ok() : BadRequest();
                    }
                case "update":
                    if(stravaEvent.updates  == null)
                    {
                        return BadRequest();
                    }
                    var updateResult = await _activityService.UpdateActivity(stravaEvent.object_id, stravaEvent.updates);
                    return updateResult ? Ok() : BadRequest();
                default:
                    var deleteResult = await _activityService.DeleteActivity(stravaEvent.object_id);
                    return deleteResult ? Ok() : BadRequest();
            }
        }
        private async Task<IActionResult> HandleAthleteEvent(StravaEvent stravaEvent)
        {
            return await _stravaAccessTokenService.DeleteStravaAccessToken(stravaEvent.object_id) ? Ok() : BadRequest();
        }

    }
}
