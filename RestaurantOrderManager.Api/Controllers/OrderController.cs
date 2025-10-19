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
        public async Task<ActionResult<Order>> GetOrderAsync(int id) {
            var order = await _orderService.GetOrderAsync(id);
            return Ok(order);
        }

        [HttpPost("new/{id}")]
        public async Task<ActionResult<Order>> CreateOrderAsync(int id, [FromBody] List<CartItem> cartItems)
        {
            var order = _orderService.CreateOrder(id, cartItems);
            var result = await _orderService.AddOrderAsync(order);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> AddOrderAsync([FromBody] Order order) { 
            await _orderService.AddOrderAsync(order);
            return Ok(order);
        }
    }
}
