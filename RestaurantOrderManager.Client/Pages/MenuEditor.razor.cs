using Microsoft.AspNetCore.Components;
using RestaurantOrderManager.Shared.Models;
using RestaurantOrderManager.Client.Services;

namespace RestaurantOrderManager.Client.Pages
{
    public partial class MenuEditor : ComponentBase
    {
        [Inject] public MenuService MenuService { get; set; }

        protected List<MenuItem> menuItems;
        protected MenuItem newMenuItem = new();
        protected string errorMessage;

        protected override async Task OnInitializedAsync()
        {
            await LoadMenu();
        }

        protected async Task LoadMenu()
        {
            try
            {
                menuItems = await MenuService.GetMenuAsync();
            }
            catch
            {
                errorMessage = "Failed to load menu items.";
            }
        }

        protected async Task AddMenuItem()
        {
            try
            {
                await MenuService.AddMenuItemAsync(newMenuItem);
                newMenuItem = new();
                await LoadMenu();
            }
            catch
            {
                errorMessage = "Failed to add menu item.";
            }
        }

        protected async Task RemoveMenuItem(int id)
        {
            try
            {
                await MenuService.RemoveMenuItemAsync(id);
                await LoadMenu();
            }
            catch
            {
                errorMessage = "Failed to remove menu item.";
            }
        }
    }
}