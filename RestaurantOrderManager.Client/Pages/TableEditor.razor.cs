using Microsoft.AspNetCore.Components;
using RestaurantOrderManager.Client.Services;
using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Client.Pages
{
    public partial class TableEditor
    {
        [Inject] public TableService TableService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        private List<Table> tables;
        private Table newTable = new();
        private string errorMessage;

        protected override async Task OnInitializedAsync()
        {
            await LoadTables();
        }

        private async Task LoadTables()
        {
            tables = await TableService.GetTablesAsync();
        }

        private async Task AddTable()
        {
            try
            {
                await TableService.AddTableAsync(newTable);
                newTable = new();
                await LoadTables();
            }
            catch
            {
                errorMessage = "Failed to add table.";
            }
        }

        private async Task RemoveTable(int id)
        {
            try
            {
                await TableService.RemoveTableAsync(id);
                await LoadTables();
            }
            catch
            {
                errorMessage = "Failed to remove table.";
            }
        }
    }
}
