using Microsoft.AspNetCore.Components;
using RestaurantOrderManager.Client.Services;
using RestaurantOrderManager.Shared.Models;
using RestaurantOrderManager.Shared.Extensions;

namespace RestaurantOrderManager.Client.Pages;

public partial class OrderCreate
{
    [Parameter] public int TableId { get; set; }
    
    [Inject] public MenuService MenuService { get; set; }
    [Inject] public OrderService OrderService { get; set; }
    [Inject] public CartService CartService { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    private List<MenuItem> _menu = new();
    private List<CartItem> _cartItems = new();
    private decimal _cartTotal = 0;

    protected override async Task OnParametersSetAsync()
    {
        _menu = await MenuService.GetMenuAsync();
        await LoadCartAsync();
    }

    private async Task LoadCartAsync() { 
        _cartItems = await CartService.GetCartItemsAsync(TableId);
        _cartTotal = await CartService.GetTotalAsync(TableId);
        StateHasChanged();
    }

    private async Task AddToCart(MenuItem menuItem)
    {
        var cartItem = menuItem.ToCartItem();
        await CartService.AddItemAsync(TableId, cartItem);
        await LoadCartAsync();
    }

    private async Task RemoveFromCart(int cartItemId) {
        await CartService.RemoveItemAsync(TableId, cartItemId);
        await LoadCartAsync();
    }

    private async Task IncreaseItemAmount(int cartItemId) { 
        await CartService.IncreaseQuantityAsync(TableId, cartItemId);
        await LoadCartAsync();
    }
    private async Task DecreaseItemAmount(int cartItemId) { 
        await CartService.DecreaseQuantityAsync(TableId, cartItemId);
        await LoadCartAsync();
    }

    private async Task ConfirmOrder()
    {
        var cartItems = await CartService.GetCartItemsAsync(TableId);
        
        await OrderService.CreateOrderAsync(TableId, cartItems);
        await CartService.ClearCartAsync(TableId);
        
        NavigationManager.NavigateTo("/active-orders");
        
        await LoadCartAsync();
    }
}