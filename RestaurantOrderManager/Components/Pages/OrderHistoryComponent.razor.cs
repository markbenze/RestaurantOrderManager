using Microsoft.AspNetCore.Components;
using RestaurantOrderManager.Services;
using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Components.Pages
{
    public partial class OrderHistoryComponent
    {
        [Inject]
        public OrderService OrderService { get; set; }

        private List<Order> Orders = new List<Order>();

        protected override async Task OnInitializedAsync()
        {
            Orders = await OrderService.GetOrdersAsync();
        }

        public async void DisposeAsync()
        {
        }
    }
}
