using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrderManager.Api.Services;
using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ICartService _cartService;

        public CartController(ICartService cartService) {
            _cartService = cartService;
        }

        [HttpGet("{tableId}")]
        public async Task<ActionResult<Cart>> GetCart(int tableId) { 
            var cart = _cartService.GetCart(tableId);
            return Ok(cart);
        }

        [HttpGet("{tableId}/items")]
        public async Task<ActionResult<List<CartItem>>> GetCartItems(int tableId) {
            var cart = _cartService.GetCart(tableId);
            return Ok(cart.Items);
        }

        [HttpGet("{tableId}/total")]
        public async Task<ActionResult<decimal>> GetTotal(int tableId) {
            var total = _cartService.GetCartTotal(tableId);
            return Ok(total);
        }

        [HttpPost("{tableId}/items")]
        public async Task<IActionResult> AddItem(int tableId, [FromBody] CartItem cartItem) {
            _cartService.AddItem(tableId, cartItem);
            return Ok();
        }

        [HttpDelete("{tableId}/items/{itemId}")]
        public IActionResult RemoveItem(int tableId, int itemId)
        {
            _cartService.RemoveItem(tableId, itemId);
            return Ok();
        }

        [HttpPost("{tableId}/items/{itemId}/increase")]
        public IActionResult IncreaseQuantity(int tableId, int itemId)
        {
            _cartService.IncreaseQuantity(tableId, itemId);
            return Ok();
        }

        [HttpPost("{tableId}/items/{itemId}/decrease")]
        public IActionResult DecreaseQuantity(int tableId, int itemId)
        {
            _cartService.DecreaseQuantity(tableId, itemId);
            return Ok();
        }

        [HttpDelete("{tableId}")]
        public IActionResult ClearCart(int tableId)
        {
            _cartService.ClearCart(tableId);
            return Ok();
        }
    }
}
