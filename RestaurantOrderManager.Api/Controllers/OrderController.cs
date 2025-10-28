using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrderManager.Api.Services;
using RestaurantOrderManager.Shared.Models;
using System.Formats.Asn1;

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

        [HttpGet("filter")]
        public async Task<ActionResult<List<Order>>> GetOrdersByStatesAsync([FromQuery] List<OrderState> states)
        {
            if (states == null || states.Count == 0)
                return BadRequest("At least one state must be specified.");

            var orders = await _orderService.GetOrdersByStatesAsync(states);
            return Ok(orders);
        }

        [HttpPost("new/{tableId}")]
        public async Task<ActionResult<Order>> CreateOrderAsync(int tableId, [FromBody] List<CartItem> cartItems)
        {
            var order = await _orderService.CreateAndAddOrderAsync(tableId, cartItems);
            return Ok(order);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Order>> AddOrderAsync([FromBody] Order order) { 
            await _orderService.AddOrderAsync(order);
            return Ok(order);
        }

        [HttpGet("{orderId}/state")]
        public async Task<ActionResult<OrderState>> GetOrderStateAsync(int orderId) { 
            var order = await _orderService.GetOrderByIdAsync(orderId);
            if(order == null)
                return NotFound();
            return Ok(order.State);
        }

        [HttpPatch("{orderId}/state")]
        public async Task<ActionResult<Order>> UpdateOrderStateAsync(int orderId, OrderState state) { 
            var result = await _orderService.UpdateOrderStateAsync(orderId, state);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveOrderAsync(int id)
        {
            var removed = await _orderService.RemoveOrderAsync(id);

            if (!removed)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllOrdersAsync()
        {
            var orders = await _orderService.GetOrdersAsync();
            foreach (var order in orders)
            {
                await _orderService.RemoveOrderAsync(order.Id);
            }
            return NoContent();
        }
    }
}
