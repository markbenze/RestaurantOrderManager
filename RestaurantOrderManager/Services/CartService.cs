using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Services;

public class CartService
{
    private readonly HttpClient _httpClient;

    public CartService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Cart?> GetCartAsync(int tableId)
    {
        return await _httpClient.GetFromJsonAsync<Cart>($"api/cart/{tableId}");
    }
    public async Task<List<CartItem>> GetCartItemsAsync(int tableId)
    {
        return await _httpClient.GetFromJsonAsync<List<CartItem>>($"api/cart/{tableId}/items");
    }

    public async Task AddItemAsync(int tableId, CartItem item)
    {
        await _httpClient.PostAsJsonAsync($"api/cart/{tableId}/items", item);
    }

    public async Task RemoveItemAsync(int tableId, int itemId)
    {
        await _httpClient.DeleteAsync($"api/cart/{tableId}/items/{itemId}");
    }

    public async Task ClearCartAsync(int tableId)
    {
        await _httpClient.DeleteAsync($"api/cart/{tableId}");
    }

    public async Task IncreaseQuantityAsync(int tableId, int itemId)
    {
        await _httpClient.PostAsync($"api/cart/{tableId}/items/{itemId}/increase", null);
    }

    public async Task DecreaseQuantityAsync(int tableId, int itemId)
    {
        await _httpClient.PostAsync($"api/cart/{tableId}/items/{itemId}/decrease", null);
    }

    public async Task<decimal> GetTotalAsync(int tableId)
    {
        return await _httpClient.GetFromJsonAsync<decimal>($"api/cart/{tableId}/total");
    }
}