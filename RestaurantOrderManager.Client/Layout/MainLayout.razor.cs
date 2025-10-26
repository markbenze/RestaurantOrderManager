using Microsoft.AspNetCore.Components;

namespace RestaurantOrderManager.Client.Layout
{
    public partial class MainLayout
    {
        [Inject] NavigationManager NavigationManager { get; set; }
        private bool IsLoginPage => NavigationManager.Uri.TrimEnd('/').Equals(NavigationManager.BaseUri.TrimEnd('/'), StringComparison.OrdinalIgnoreCase);
    }
}
