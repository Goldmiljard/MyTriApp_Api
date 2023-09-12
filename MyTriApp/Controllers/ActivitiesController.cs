using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using MyTriApp.Data.Entities;
using MyTriApp.Services.Interfaces;
using MyTriApp.Strava_API;

namespace MyTriApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private IUserService _userService;
        private readonly IConfiguration _configuration;
        private IActivityService _activityService;
        private IStravaAPI _stravaAPI;

        public ActivitiesController(IUserService userService, IConfiguration configuration, IActivityService activityService, IStravaAPI stravaAPI)
        {
            _userService = userService;
            _configuration = configuration;
            _activityService = activityService;
            _stravaAPI = stravaAPI;
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            //get current user
            var userIdClaim = User.FindFirst("userid");
            if (userIdClaim == null)
            {
                return BadRequest();
            }
            var userId = new Guid(userIdClaim.Value);

            //call database service to get activities from db
            var activities = await _activityService.GetActivities(userId);
            //if there are no activities in db yet time to retrieve activities from strava
            if(activities.Count == 0)
            {
                var user = await _userService.GetUserById(userId);
                if (user?.StravaAccessToken == null)
                {
                    return new List<Activity>();
                }
                if (DateTimeOffset.FromUnixTimeSeconds(user.StravaAccessToken.ExpiresAt).DateTime < DateTime.Now)
                {
                    var accessTokenDTO = await _stravaAPI.RefreshStravaAccessToken(user.StravaAccessToken);
                    user.StravaAccessToken = StravaAccessToken.From(accessTokenDTO, user.ExternalId);
                    await _userService.UpdateUser(user);
                }
                var activityDTOs = await _stravaAPI.GetActivities(user.StravaAccessToken);
                //convert to activity entity
                activities = activityDTOs.Select(x => x.ToActivity(x, userId)).ToList();
                //save retrieved activities to database
                var activityEntries = await _activityService.SaveActivities(activities);
                activities = activityEntries;
            }

            return activities;
        }
    }
}
