using Microsoft.AspNetCore.Components;
using RestaurantOrderManager.Client.Services;
using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Client.Pages;

public partial class Tables
{
    private List<Table> _tables = new();

    [Inject] 
    public TableService TableService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _tables = await TableService.GetTablesAsync();
    }
}