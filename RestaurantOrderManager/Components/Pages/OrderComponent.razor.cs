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
    [Parameter] public EventCallback OnOrderConfirmed { get; set; }

    private int SelectedMenuItemId;
    private int Quantity = 1;
    private Order? PlacedOrder;

    private void AddItem()
    {
        var menuItem = MenuService.GetMenu().FirstOrDefault(m => m.Id == SelectedMenuItemId);
        if (menuItem != null)
        {
            CartService.AddMenuItem(menuItem, Quantity);
            Quantity = 1;
        }
    }

    private void RemoveItem(int cartItemId) => CartService.RemoveCartItem(cartItemId);

    private void ConfirmOrder()
    {
        var cartCopy = CartService.CartItems.ToList();
        
        PlacedOrder = OrderService.CreateOrder(TableId, cartCopy);

        CartService.ClearCart(); 
        OnOrderConfirmed.InvokeAsync();
    }

    protected override void OnInitialized()
    {
        CartService.OnChange += StateHasChanged;
    }
    
    public void Dispose()
    {
        CartService.OnChange -= StateHasChanged;
    }
}