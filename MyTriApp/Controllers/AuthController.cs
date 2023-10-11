using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTriApp.Data.Entities;
using MyTriApp.DTO;
using MyTriApp.Services.Interfaces;

namespace MyTriApp.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;
        private ITokenService _tokenService;

        public AuthController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody] RegisterData registerData)
        {
            if (registerData.Password != registerData.PasswordConfirmation)
            {
                return BadRequest();
            }

            var user = await _userService.GetUserByEmail(registerData.Email);

            //if user is not found we can continue otherwise return badrequest
            if (user != null)
            {
                return BadRequest();
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerData.Password);
            var createdUser = await _userService.CreateUser(new User(registerData.Email, hashedPassword));

            if (createdUser != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginData loginData)
        {
            var user = await _userService.GetUserByEmail(loginData.Email);
            var userDoesntExist = user == null;

            if (userDoesntExist)
            {
                return Unauthorized();
            }
            else
            {
                var wrongPassword = !BCrypt.Net.BCrypt.Verify(loginData.Password, user?.PasswordHash);

                if (wrongPassword)
                {
                    return Unauthorized();
                }

                var token = await _tokenService.GetUserToken(user);

                return Ok(token);
            }            
        }

    }
}
