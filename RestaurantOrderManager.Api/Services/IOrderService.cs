using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Api.Services
{
    public interface IOrderService
    {
        Task<Order> CreateAndAddOrderAsync(int tableId, List<CartItem> cartItems);
        Task<Order> AddOrderAsync(Order order);
        Task<List<Order>> GetOrdersAsync();
        Task<Order> UpdateOrderStateAsync(int orderId, OrderState state);
        Task<bool> RemoveOrderAsync(int id);
        Task<Order?> GetOrderByIdAsync(int id);
    }
}
