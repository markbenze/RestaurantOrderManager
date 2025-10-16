using Microsoft.AspNetCore.Components;
using RestaurantOrderManager.Services;
using RestaurantOrderManager.Shared.Models;
using RestaurantOrderManager.Shared.Extensions;

namespace RestaurantOrderManager.Components.Pages;

public partial class OrderComponent : IDisposable
{
    [Parameter] public int TableId { get; set; }
    
    [Inject] public MenuService MenuService { get; set; }
    [Inject] public OrderService OrderService { get; set; }
    [Inject] public CartService CartService { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }


    private List<MenuItem> Menu = new();
    private List<CartItem> CartItems = new();
    private decimal CartTotal = 0;

    protected override async Task OnInitializedAsync()
    {
        Menu = await MenuService.GetMenuAsync();
        await LoadCartAsync();
    }

    private async Task LoadCartAsync() { 
        CartItems = await CartService.GetCartItemsAsync(TableId);
        CartTotal = await CartService.GetTotalAsync(TableId);
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
        var _placedOrder = await OrderService.CreateOrderAsync(TableId, cartItems);
        await OrderService.AddOrderAsync(_placedOrder);
        await CartService.ClearCartAsync(TableId);
        NavigationManager.NavigateTo("/order-history");
        await LoadCartAsync();
    }

    public async void Dispose()
    {
        await CartService.ClearCartAsync(TableId);
    }
}