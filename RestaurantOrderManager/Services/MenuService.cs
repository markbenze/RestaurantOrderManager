using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Services;

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
}