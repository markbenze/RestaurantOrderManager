using Microsoft.AspNetCore.Components;
using RestaurantOrderManager.Services;
using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Components.Pages;

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