using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTriApp.Data.Entities;
using MyTriApp.Services.Interfaces;
using MyTriApp.Strava_API;

namespace MyTriApp.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class StravaAuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IStravaAPI _stravaAPI;
        private readonly IStravaAccessTokenService _stravaAccessTokenService;

        public StravaAuthenticationController(IUserService userService, IStravaAPI stravaAPI, IStravaAccessTokenService stravaAccessTokenService)
        {
            _userService = userService;
            _stravaAPI = stravaAPI;
            _stravaAccessTokenService = stravaAccessTokenService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStravaAuthenticationStatus()
        {
            var useridString = User.FindFirst("userid")?.Value ?? string.Empty;

            if (useridString == string.Empty)
            {
                return BadRequest();
            }

            var userGuid = new Guid(useridString);

            var user = await _userService.GetUserById(userGuid);

            if (user == null)
            {
                return BadRequest();
            }

            return user.StravaAccessToken == null ? Ok(false) : Ok(true);
        }

        [HttpPost]
        public async Task<IActionResult> AuthenticateStrava([FromQuery] string code)
        {
            var stravaAccessTokenDTO = await _stravaAPI.GetStravaAccessToken(code);

            if (stravaAccessTokenDTO == null)
            {
                return BadRequest("Failed to obtain strava access token.");
            }
                    
            var userGuid = new Guid(User.FindFirst("userid")?.Value);

            var user = await _userService.GetUserById(userGuid);

            if (user == null)
            {
                return BadRequest();
            }

            var stravaAccessToken = StravaAccessToken.From(stravaAccessTokenDTO, user.ExternalId);

            await _stravaAccessTokenService.CreateStravaAccessToken(stravaAccessToken);

            return Ok();
        }
    }
}
