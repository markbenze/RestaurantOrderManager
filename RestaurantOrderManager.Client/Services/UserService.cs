using RestaurantOrderManager.Shared.Models;
using System.Net.Http.Json;

namespace RestaurantOrderManager.Client.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<User>>("api/user");
        }

        public async Task<User> AddUserAsync(User user)
        {
            var response = await _httpClient.PostAsJsonAsync("api/user", user);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<User>();
        }

        public async Task RemoveUserAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/user/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
