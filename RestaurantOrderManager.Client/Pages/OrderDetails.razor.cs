using Microsoft.AspNetCore.Components;
using RestaurantOrderManager.Client.Services;
using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Client.Pages
{
    public partial class OrderDetails
    {
        [Parameter] public int OrderId { get; set; }
        [Inject] public OrderService OrderService { get; set; }
        [Inject] public NavigationManager Navigation { get; set; }

        private Order _currentOrder = new();

        protected override async Task OnParametersSetAsync()
        {
            _currentOrder = await OrderService.GetOrderByIdAsync(OrderId);
        }
        private async Task CancelOrder()
        {
            if (_currentOrder != null)
            {
                _currentOrder.State = OrderState.Cancelled;
                await OrderService.UpdateOrderAsync(_currentOrder);
                StateHasChanged();
            }
        }

        private async Task SendToKitchen()
        {
            if (_currentOrder != null)
            {
                _currentOrder.State = OrderState.InProgress;
                await OrderService.UpdateOrderAsync(_currentOrder);
                StateHasChanged();
            }
        }

        private void GoToCheckout()
        {
            if (_currentOrder != null)
            {
                Navigation.NavigateTo($"/checkout/{_currentOrder.Id}");
            }
        }
    }
}
