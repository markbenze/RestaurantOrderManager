using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using RestaurantOrderManager.Client.Authentication;
using RestaurantOrderManager.Shared.Models;
using System.Net.Http.Json;

namespace RestaurantOrderManager.Client.Pages
{
    public partial class Login
    {
        [Inject] private HttpClient _httpClient { get; set; }
        [Inject] private NavigationManager Navigation { get; set; }
        [Inject] private IJSRuntime JS { get; set; }
        [Inject]private AuthenticationStateProvider AuthProvider { get; set; }

        private LoginModel _loginModel = new();
        private string errorMessage = "";

        private async Task HandleLogin()
        {
            errorMessage = string.Empty;
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/auth/login", _loginModel);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<LoginResult>();
                    await JS.InvokeVoidAsync("localStorage.setItem", "authToken", result.token);

                    if (AuthProvider is JwtAuthenticationStateProvider jwtProvider)
                    {
                        jwtProvider.NotifyAuthenticationStateChanged();
                    }

                    Navigation.NavigateTo("/tables");
                }
                else
                {
                    errorMessage = "Invalid username or password.";
                }
            }
            catch
            {
                errorMessage = "Login failed. Please try again.";
            }
        }
    }

    public class LoginResult
    {
        public string token { get; set; }
    }
}
