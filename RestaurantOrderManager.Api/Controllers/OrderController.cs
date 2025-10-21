using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrderManager.Api.Services;
using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService) {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetOrdersAsync() {
            var orders = await _orderService.GetOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderByIdAsync(int id) {
            var order = await _orderService.GetOrderByIdAsync(id);
            return Ok(order);
        }

        [HttpPost("new/{id}")]
        public async Task<ActionResult<Order>> CreateOrderAsync(int id, [FromBody] List<CartItem> cartItems)
        {
            var order = await _orderService.CreateAndAddOrderAsync(id, cartItems);
            return Ok(order);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Order>> AddOrderAsync([FromBody] Order order) { 
            await _orderService.AddOrderAsync(order);
            return Ok(order);
        }
    }
}
