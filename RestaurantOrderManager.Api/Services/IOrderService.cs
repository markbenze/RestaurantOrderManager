using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Api.Services
{
    public interface IOrderService
    {
        Order CreateOrder(int tableId, List<CartItem> cartItems);
        Task<Order> AddOrderAsync(Order order);
        Task<List<Order>> GetOrdersAsync();
        Task<Order?> GetOrderAsync(int id);
    }
}
