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
            var orders = await Task.Run(() => _orderService.GetOrders());
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderAsync(int id) {
            var order = await Task.Run(() => _orderService.GetOrder(id));
            return Ok(order);
        }

        [HttpPost("new/{id}")]
        public async Task<IActionResult> CreateOrderAsync(int id, [FromBody] List<CartItem> cartItems)
        {
            var order = await Task.Run(() => _orderService.CreateOrder(id, cartItems));
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderAsync([FromBody] Order order) { 
            await Task.Run(() => _orderService.AddOrder(order));
            return Ok(order);
        }
    }
}
