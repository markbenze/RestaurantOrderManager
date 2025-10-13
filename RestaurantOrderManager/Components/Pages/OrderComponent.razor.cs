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

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter] public int TableId { get; set; }

    private Order? _placedOrder;

    private void AddToCart(int id, int quantity = 1)
    {
        CartService.AddCartItem(id, quantity);
    }

    private void RemoveFromCart(int cartItemId) => CartService.RemoveCartItem(cartItemId);

    private void DecreaseItemAmount(int cartItemId) => CartService.DecreaseCartItem(cartItemId);

    private void ConfirmOrder()
    {
        _placedOrder = OrderService.CreateOrder(TableId, CartService.GetCartItems());
        OrderService.AddOrder(_placedOrder);
        CartService.ClearCart();
        NavigationManager.NavigateTo("/order-history");
    }

    protected override void OnInitialized()
    {
    }
    
    public void Dispose()
    {
        CartService.ClearCart();
    }
}