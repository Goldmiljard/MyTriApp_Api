using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTriApp.Data.Entities;
using MyTriApp.Services.Interfaces;

namespace MyTriApp.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private IActivityService _activityService;

        public ActivitiesController(IActivityService activityService)
        {
            _activityService = activityService;
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

            var activities = await _activityService.GetActivities(userId);

            return Ok(activities);
        }

        [HttpGet("{id}")]
        private async Task<ActionResult<Activity>> GetActivityById(long id)
        {
            //get current user
            var userIdClaim = User.FindFirst("userid");
            if (userIdClaim == null)
            {
                return BadRequest();
            }
            var userId = new Guid(userIdClaim.Value);

            return Ok(await _activityService.GetActivityById(id, userId));
        }
    }
}
