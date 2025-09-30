using Microsoft.AspNetCore.Components;
using RestaurantOrderManager.Models;
using RestaurantOrderManager.Services;

namespace RestaurantOrderManager.Components.Pages;

public partial class Index
{
    private List<Table> Tables { get; set; }

    [Inject] 
    public TableService TableService { get; set; }

    protected override Task OnInitializedAsync()
    {
        Tables = TableService.GetTables();
        return Task.CompletedTask;
    }
}