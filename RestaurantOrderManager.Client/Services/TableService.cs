using RestaurantOrderManager.Shared.Models;
using System.Net.Http.Json;

namespace RestaurantOrderManager.Client.Services;

public class TableService
{
    private readonly HttpClient _httpClient;

    public TableService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Table>> GetTablesAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Table>>("api/table");
    }

    public async Task<Table> GetTableAsync(int id) {
        return await _httpClient.GetFromJsonAsync<Table>($"api/table/{id}");
    }

    public async Task<Table> AddTableAsync(Table table)
    {
        var response = await _httpClient.PostAsJsonAsync("api/table", table);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Table>();
    }

    public async Task RemoveTableAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/table/{id}");
        response.EnsureSuccessStatusCode();
    }
}