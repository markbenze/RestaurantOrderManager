using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Api.Services
{
    public interface ITableService
    {
        Task<List<Table>> GetTablesAsync();
        Task<Table?> GetTableAsync(int id);
        Task<Table> AddTableAsync(Table table);
        Task<bool> RemoveTableAsync(int id);
    }
}
