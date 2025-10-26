using Microsoft.AspNetCore.Components;
using RestaurantOrderManager.Client.Services;
using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Client.Pages
{
    public partial class Checkout
    {
        [Parameter] public int OrderId { get; set; }

        [Inject] OrderService OrderService { get; set; }
        [Inject] NavigationManager Navigation { get; set; }

        private Order? _order;

        protected override async Task OnInitializedAsync()
        {
            _order = await FetchOrderAsync(OrderId);
        }

        private async Task<Order> FetchOrderAsync(int orderId)
        {
            return await OrderService.GetOrderByIdAsync(orderId);
        }

        private async Task CompleteCheckout()
        {
            if (_order != null)
            {
                _order.State = OrderState.Completed;

                await OrderService.UpdateOrderAsync(_order);

                Navigation.NavigateTo("/tables");
            }
        }
    }
}
