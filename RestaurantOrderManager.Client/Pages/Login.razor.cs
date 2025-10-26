using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Client.Pages
{
    public partial class Login
    {
        private LoginModel _loginModel = new();

        private void HandleLogin()
        {
            Navigation.NavigateTo("/tables");
        }
    }
}
