using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Services;

public class OrderService
{
    private readonly HttpClient _httpClient;
    
    public OrderService(HttpClient httpClient) {
        _httpClient = httpClient;    
    }

    public async Task<List<Order>> GetOrdersAsync() => await _httpClient.GetFromJsonAsync<List<Order>>("api/order");

    public async Task<Order> GetOrderByIdAsync(int id) => await _httpClient.GetFromJsonAsync<Order>($"api/order/{id}");

    public async Task AddOrderAsync(Order order) => await _httpClient.PostAsJsonAsync("api/order/add", order);

    public async Task<Order> CreateOrderAsync(int id, List<CartItem> cartItems) {
        var response = await _httpClient.PostAsJsonAsync($"api/order/new/{id}", cartItems);
        return await response.Content.ReadFromJsonAsync<Order>();
    } 
}