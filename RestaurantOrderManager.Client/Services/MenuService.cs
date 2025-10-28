using RestaurantOrderManager.Shared.Models;
using System.Net.Http.Json;

namespace RestaurantOrderManager.Client.Services;

public class MenuService
{
    private readonly HttpClient _httpClient;

    public MenuService(HttpClient httpClient) { 
        _httpClient = httpClient;
    }

    public async Task<List<MenuItem>> GetMenuAsync() { 
        return await _httpClient.GetFromJsonAsync<List<MenuItem>>("api/menu");
    }

    public async Task<MenuItem> GetMenuItemAsync(int id) { 
        return await _httpClient.GetFromJsonAsync<MenuItem>($"api/menu/{id}");
    }

    public async Task<MenuItem> AddMenuItemAsync(MenuItem item)
    {
        var response = await _httpClient.PostAsJsonAsync("api/menu", item);
        return await response.Content.ReadFromJsonAsync<MenuItem>();
    }
    public async Task<bool> RemoveMenuItemAsync(int id) {
        var response = await _httpClient.DeleteAsync($"api/menu/{id}");
        return response.IsSuccessStatusCode;
    }
}