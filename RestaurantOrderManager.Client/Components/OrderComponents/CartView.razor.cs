using Microsoft.AspNetCore.Components;
using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Client.Components.OrderComponents
{
    public partial class CartView
    {
        [Parameter] public List<CartItem>? Items { get; set; }
        [Parameter] public decimal Total { get; set; }

        [Parameter] public EventCallback OnConfirmRequested { get; set; }
        [Parameter] public EventCallback<int> OnIncreaseRequested { get; set; }
        [Parameter] public EventCallback<int> OnDecreaseRequested { get; set; }
        [Parameter] public EventCallback<int> OnRemoveRequested { get; set; }

        private Task ForwardIncrease(int id) => OnIncreaseRequested.InvokeAsync(id);
        private Task ForwardDecrease(int id) => OnDecreaseRequested.InvokeAsync(id);
        private Task ForwardRemove(int id) => OnRemoveRequested.InvokeAsync(id);


    }
}
