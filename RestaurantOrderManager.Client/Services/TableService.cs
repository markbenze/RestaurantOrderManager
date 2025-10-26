using RestaurantOrderManager.Shared.Models;
using System.Net.Http.Json;
using Microsoft.JSInterop;

namespace RestaurantOrderManager.Client.Services;

public class TableService
{
    private readonly HttpClient _httpClient;
    private readonly IJSRuntime JS;

    public TableService(HttpClient httpClient, IJSRuntime jsRuntime)
    {
        _httpClient = httpClient;
        JS = jsRuntime;
    }

    public async Task<List<Table>> GetTablesAsync()
    {
        var token = await JS.InvokeAsync<string>("localStorage.getItem", "authToken");
        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
        return await _httpClient.GetFromJsonAsync<List<Table>>("api/table");
    }

    public async Task<Table> GetTableAsync(int id) {
        var token = await JS.InvokeAsync<string>("localStorage.getItem", "authToken");
        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
        return await _httpClient.GetFromJsonAsync<Table>($"api/table/{id}");
    }

    public async Task<Table> AddTableAsync(Table table)
    {
        var token = await JS.InvokeAsync<string>("localStorage.getItem", "authToken");
        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
        var response = await _httpClient.PostAsJsonAsync("api/table", table);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Table>();
    }

    public async Task RemoveTableAsync(int id)
    {
        var token = await JS.InvokeAsync<string>("localStorage.getItem", "authToken");
        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
        var response = await _httpClient.DeleteAsync($"api/table/{id}");
        response.EnsureSuccessStatusCode();
    }
}