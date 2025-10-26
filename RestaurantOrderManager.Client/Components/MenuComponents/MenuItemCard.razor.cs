using Microsoft.AspNetCore.Components;
using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Client.Components.MenuComponents
{
    public partial class MenuItemCard
    {
        [Parameter] public MenuItem Item { get; set; }
        [Parameter] public EventCallback<MenuItem> OnAddRequested { get; set; }

        private Task RequestAddAsync() => OnAddRequested.InvokeAsync(Item);
    }
}
