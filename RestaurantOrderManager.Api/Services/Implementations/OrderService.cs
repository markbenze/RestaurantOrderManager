using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantOrderManager.Api.Data;
using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Api.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly RestaurantDbContext _appDbContext;

        public OrderService(RestaurantDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Order> CreateAndAddOrderAsync(int tableId, List<CartItem> cartItems)
        {
            var order = BuildOrder(tableId, cartItems);

            _appDbContext.Orders.Add(order);
            await _appDbContext.SaveChangesAsync();

            return order;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            _appDbContext.Orders.Add(order);
            await _appDbContext.SaveChangesAsync();

            return order;
        }

        public async Task<List<Order>> GetOrdersAsync() {
            return await _appDbContext.Orders
                .Include(o => o.OrderItems)
                .ToListAsync();
        }
    
        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _appDbContext.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    
        private Order BuildOrder(int tableId, List<CartItem> cartItems)
        {
            var order = new Order
            {
                TableId = tableId,
                State = OrderState.Pending,
                OrderItems = cartItems.Select(item => new OrderItem
                {
                    MenuItemId = item.MenuItemId,
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity
                }).ToList()
            };

            order.Total = order.OrderItems.Sum(item => item.Total);
            return order;
        }
    }
}
