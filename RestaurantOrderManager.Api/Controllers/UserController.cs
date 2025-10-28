using Microsoft.AspNetCore.Mvc;
using RestaurantOrderManager.Shared.Models;
using RestaurantOrderManager.Api.Services;

namespace RestaurantOrderManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
            => await _userService.GetUsersAsync();

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            var addedUser = await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUsers), new { id = addedUser.Id }, addedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var success = await _userService.DeleteUserAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
