using Microsoft.AspNetCore.Components;
using RestaurantOrderManager.Client.Services;
using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Client.Pages
{
    public partial class OrderDetails
    {
        [Parameter] public int OrderId { get; set; }
        [Inject] public OrderService OrderService { get; set; }

        private Order _currentOrder = new();

        private List<OrderState> _orderStates = Enum.GetValues<OrderState>().ToList();

        protected override async Task OnParametersSetAsync()
        {
            _currentOrder = await OrderService.GetOrderByIdAsync(OrderId);
        }

        public async Task UpdateOrderState(OrderState newState)
        {
            _currentOrder.State = newState;
            await OrderService.UpdateOrderAsync(_currentOrder);
        }
    }
}
