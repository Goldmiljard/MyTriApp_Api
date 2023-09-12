using Microsoft.AspNetCore.Mvc;
using MyTriApp.Data.Entities;
using MyTriApp.Services.Interfaces;

namespace MyTriApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(Guid userId)
        {
            var user = await _userService.GetUserById(userId);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            var createdUser = await _userService.CreateUser(user);

            if (createdUser == null)
            {
                return NotFound();
            }

            return Ok(createdUser);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(User userUpdate)
        {
            var updatedUser = await _userService.UpdateUser(userUpdate);

            if (updatedUser == null)
            {
                return NotFound();
            }

            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            var isDeleted = await _userService.DeleteUserById(id);

            if (!isDeleted)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
