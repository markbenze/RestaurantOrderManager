using RestaurantOrderManager.Models;

namespace RestaurantOrderManager.Services;

public class CartService
{
    private List<CartItem> _cartItems { get; } = new();
    //public event Action? OnChange;

    private MenuService _menuService;
    
    public CartService(MenuService menuService)
    {
        this._menuService = menuService;
    }
    
    //private void NotifyStateChanged() => OnChange?.Invoke();
    
    public void AddCartItem(int menuItemId, int quantity = 1)
    {
        if (quantity < 0)
        {
            return;
        }

        var menuItem = _menuService.GetMenuItem(menuItemId);
        if (menuItem != null)
        {
            var existingItem = _cartItems.FirstOrDefault(i => i.Id == menuItemId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _cartItems.Add(new CartItem
                {
                    Id = menuItem.Id,
                    Name = menuItem.Name,
                    Price = menuItem.Price,
                    Quantity = quantity
                });
            } 
        }
        //NotifyStateChanged();  
    }

    public void DecreaseCartItem(int cartItemId) {
        var item = _cartItems.FirstOrDefault(i => i.Id == cartItemId);
        if (item != null)
        {
            if (item.Quantity > 1)
            {
                item.Quantity--;
            }
            else
            {
                _cartItems.Remove(item);
            }
            //NotifyStateChanged();
        }
        else {
            return;
        }
    }

    public void RemoveCartItem(int cartItemId)
    {
        var item = _cartItems.FirstOrDefault(i => i.Id == cartItemId);
        if (item != null)
        {
            _cartItems.Remove(item);
        }
        //NotifyStateChanged();  
    }
    
    public void ClearCart()
    {
        _cartItems.Clear();
        //NotifyStateChanged();  
    }

    public decimal GetTotal() => _cartItems.Sum(i => i.Total);

    public List<CartItem> GetCartItems() => _cartItems.Select(item => new CartItem
    {
        Id = item.Id,
        Name = item.Name,
        Price = item.Price,
        Quantity = item.Quantity
    }).ToList();

}