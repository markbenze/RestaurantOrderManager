using RestaurantOrderManager.Shared.Models;
using System.Net.Http.Json;

namespace RestaurantOrderManager.Client.Services;

public class OrderService
{
    private readonly HttpClient _httpClient;
    
    public OrderService(HttpClient httpClient) {
        _httpClient = httpClient;    
    }

    public async Task<List<Order>> GetOrdersAsync() => await _httpClient.GetFromJsonAsync<List<Order>>("api/order");

    public async Task<Order> GetOrderByIdAsync(int id) => await _httpClient.GetFromJsonAsync<Order>($"api/order/{id}");

    public async Task AddOrderAsync(Order order) => await _httpClient.PostAsJsonAsync("api/order/add", order);

    public async Task UpdateOrderAsync(Order order) => await _httpClient.PatchAsync($"api/order/{order.Id}/state?state={order.State}", null);

    public async Task<Order> CreateOrderAsync(int id, List<CartItem> cartItems) {
        var response = await _httpClient.PostAsJsonAsync($"api/order/new/{id}", cartItems);
        return await response.Content.ReadFromJsonAsync<Order>();
    } 
}