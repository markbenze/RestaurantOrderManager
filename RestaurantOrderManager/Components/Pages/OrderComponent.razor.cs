using Microsoft.AspNetCore.Components;
using RestaurantOrderManager.Models;
using RestaurantOrderManager.Services;

namespace RestaurantOrderManager.Components.Pages;

public partial class OrderComponent : IDisposable
{
    [Inject]
    public MenuService MenuService { get; set; }
    
    [Inject]
    public OrderService OrderService { get; set; }
    
    [Inject]
    public CartService CartService { get; set; }

    [Parameter] public int TableId { get; set; }

    private int _selectedMenuItemId;
    private int _quantity = 1;
    private Order? _placedOrder;

    private void AddItem()
    {
        CartService.AddCartItem(_selectedMenuItemId, _quantity);
        _quantity = 1;
    }

    private void RemoveItem(int cartItemId) => CartService.RemoveCartItem(cartItemId);

    private void ConfirmOrder()
    {
        _placedOrder = OrderService.CreateOrder(TableId, CartService.GetCartItems());
        OrderService.AddOrder(_placedOrder);
        CartService.ClearCart();
    }

    protected override void OnInitialized()
    {
        CartService.OnChange += StateHasChanged;
    }
    
    public void Dispose()
    {
        CartService.OnChange -= StateHasChanged;
        CartService.ClearCart();
    }
}