using Microsoft.AspNetCore.Components;
using RestaurantOrderManager.Shared.Models;
using RestaurantOrderManager.Client.Services;

namespace RestaurantOrderManager.Client.Pages
{
    public partial class ActiveOrders : ComponentBase
    {
        [Inject] private OrderService OrderService { get; set; }

        protected List<Order> orders;
        protected string errorMessage;

        protected override async Task OnInitializedAsync()
        {
            await LoadOrders();
        }

        protected async Task LoadOrders()
        {
            try
            {
                orders = await OrderService.GetOrdersByStatesAsync(OrderState.Pending, OrderState.InProgress);
            }
            catch
            {
                errorMessage = "Failed to load active orders.";
            }
        }
    }
}