using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Api.Services
{
    public interface ICartService
    {
        Cart GetCart(int tableId);
        void AddItem(int tableId, CartItem item);
        void RemoveItem(int tableId, int itemId);
        void ClearCart(int tableId);
        void IncreaseQuantity(int tableId, int itemId);
        void DecreaseQuantity(int tableId, int itemId);
        decimal GetCartTotal(int tableId);
    }
}
