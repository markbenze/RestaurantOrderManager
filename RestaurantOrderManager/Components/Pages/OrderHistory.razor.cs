using Microsoft.AspNetCore.Components;
using RestaurantOrderManager.Services;
using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Components.Pages
{
    public partial class OrderHistory
    {
        [Inject]
        public OrderService OrderService { get; set; }

        private List<Order> _orders = new List<Order>();

        protected override async Task OnInitializedAsync()
        {
            _orders = await OrderService.GetOrdersAsync();
        }

        public async void DisposeAsync()
        {
        }
    }
}
