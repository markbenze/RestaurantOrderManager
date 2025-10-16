using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Api.Services
{
    public interface IOrderService
    {
        Order CreateOrder(int tableId, List<CartItem> cartItems);
        void AddOrder(Order order);
        List<Order> GetOrders();

        Order? GetOrder(int id);
    }
}
