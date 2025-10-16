using Microsoft.Extensions.Diagnostics.HealthChecks;
using RestaurantOrderManager.Shared.Models;
using System.Net;

namespace RestaurantOrderManager.Services;

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
}