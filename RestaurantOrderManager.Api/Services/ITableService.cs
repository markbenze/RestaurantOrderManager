using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Api.Services
{
    public interface ITableService
    {
        List<Table> GetTables();

        Table? GetTable(int id);
    }
}
