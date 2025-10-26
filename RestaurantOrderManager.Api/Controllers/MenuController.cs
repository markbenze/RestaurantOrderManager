using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrderManager.Api.Services;
using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService) {
            _menuService = menuService;
        }   

        [HttpGet]
        public async Task<ActionResult<List<MenuItem>>> GetMenuAsync() { 
            var menu = await _menuService.GetMenuAsync();
            return Ok(menu);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItem>> GetMenuItemAsync(int id) {
            var menuItem = await _menuService.GetMenuItemAsync(id);
            return Ok(menuItem);
        }   
    }
}
