using Microsoft.AspNetCore.Components;
using RestaurantOrderManager.Services;
using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Components.Pages;

public partial class TableView
{
    private List<Table> Tables = new();

    [Inject] 
    public TableService TableService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Tables = await TableService.GetTablesAsync();
    }
}