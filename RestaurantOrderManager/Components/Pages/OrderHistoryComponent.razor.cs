using Microsoft.AspNetCore.Components;
using RestaurantOrderManager.Services;

namespace RestaurantOrderManager.Components.Pages
{
    public partial class OrderHistoryComponent
    {
        [Inject]
        public OrderService OrderService { get; set; }

        protected override void OnInitialized()
        {
        }

        public async void DisposeAsync()
        {
        }
    }
}
