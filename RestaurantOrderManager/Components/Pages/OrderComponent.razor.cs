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

    private Order? _placedOrder;

    private Dictionary<int, int> Quantities = new();

    private void AddToCart(int id, int quantity)
    {
        CartService.AddCartItem(id, quantity);
        Quantities[id] = 1;
    }

    private void RemoveFromCart(int cartItemId) => CartService.RemoveCartItem(cartItemId);

    private void ConfirmOrder()
    {
        _placedOrder = OrderService.CreateOrder(TableId, CartService.GetCartItems());
        OrderService.AddOrder(_placedOrder);
        CartService.ClearCart();
    }

    public void Increment(int id)
    {
        Quantities[id]++;
    }

    public void Decrement(int id)
    {
        if (Quantities[id] > 1)
        {
            Quantities[id]--;
        }
    }

    protected override void OnInitialized()
    {
        CartService.OnChange += StateHasChanged;
        foreach (var item in MenuService.GetMenu())
        {
            Quantities[item.Id] = 1;
        }
    }
    
    public void Dispose()
    {
        CartService.OnChange -= StateHasChanged;
        CartService.ClearCart();
    }
}