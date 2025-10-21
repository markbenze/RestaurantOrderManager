using Microsoft.AspNetCore.Components;
using RestaurantOrderManager.Services;
using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Components.Pages
{
    public partial class OrderDetails
    {
        [Parameter] public int OrderId { get; set; }
        [Inject] public OrderService OrderService { get; set; }

        private Order _currentOrder = new();

        protected override async Task OnParametersSetAsync()
        {
            _currentOrder = await OrderService.GetOrderByIdAsync(OrderId);
        }
    }
}
