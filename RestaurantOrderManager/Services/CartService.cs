using RestaurantOrderManager.Models;

namespace RestaurantOrderManager.Services;

public class CartService
{
    public List<CartItem> CartItems { get; } = new();

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
    
    public void AddMenuItem(MenuItem menuItem, int quantity = 1)
    {
        var existingItem = CartItems.FirstOrDefault(i => i.Id == menuItem.Id);
        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            CartItems.Add(new CartItem
            {
                Id = menuItem.Id,
                Name = menuItem.Name,
                Price = menuItem.Price,
                Quantity = quantity
            });
        }
        NotifyStateChanged();  
    }
    
    public void RemoveCartItem(int cartItemId)
    {
        var item = CartItems.FirstOrDefault(i => i.Id == cartItemId);
        if (item != null)
        {
            CartItems.Remove(item);
        }
        NotifyStateChanged();  
    }
    
    public void ClearCart()
    {
        CartItems.Clear();
        NotifyStateChanged();  
    }

    public decimal GetTotal() => CartItems.Sum(i => i.Total);
    
}