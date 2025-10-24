using Microsoft.AspNetCore.Components;
using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Client.Components.OrderComponents
{
    public partial class CartItemCard
    {
        [Parameter] public CartItem Item { get; set; }

        [Parameter] public EventCallback<int> OnIncreaseRequested { get; set; }
        [Parameter] public EventCallback<int> OnDecreaseRequested { get; set; }
        [Parameter] public EventCallback<int> OnRemoveRequested { get; set; }

        private Task RequestIncreaseAsync() => OnIncreaseRequested.InvokeAsync(Item.MenuItemId);
        private Task RequestDecreaseAsync() => OnDecreaseRequested.InvokeAsync(Item.MenuItemId);
        private Task RequestRemoveAsync() => OnRemoveRequested.InvokeAsync(Item.MenuItemId);

    }
}
