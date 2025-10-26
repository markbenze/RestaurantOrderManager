using Microsoft.AspNetCore.Components;
using RestaurantOrderManager.Client.Services;
using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Client.Pages
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
    }
}
