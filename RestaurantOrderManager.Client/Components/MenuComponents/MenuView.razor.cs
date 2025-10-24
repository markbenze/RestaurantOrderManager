using Microsoft.AspNetCore.Components;
using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Client.Components.MenuComponents
{
    public partial class MenuView
    {
        [Parameter] public IEnumerable<MenuItem>? Menu { get; set; }
        [Parameter] public EventCallback<MenuItem> OnAddRequested { get; set; }

        private Task ForwardAddAsync(MenuItem item) => OnAddRequested.InvokeAsync(item);
    }
}
