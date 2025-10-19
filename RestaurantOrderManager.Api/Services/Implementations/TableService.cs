using Microsoft.EntityFrameworkCore;
using RestaurantOrderManager.Api.Data;
using RestaurantOrderManager.Shared.Models;
using System.Threading.Tasks;

namespace RestaurantOrderManager.Api.Services.Implementations
{
    public class TableService: ITableService
    {
        private readonly RestaurantDbContext _appDbContext;

        public TableService(RestaurantDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Table>> GetTablesAsync()
        {
            return await _appDbContext.Tables.ToListAsync();
        }

        public async Task<Table?> GetTableAsync(int id)
        {
            return await _appDbContext.Tables.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Table> AddTableAsync(Table table)
        {
            _appDbContext.Tables.Add(table);
            await _appDbContext.SaveChangesAsync();

            return table;
        }
        public async Task<bool> RemoveTableAsync(int id)
        {
            var table = await _appDbContext.Tables.FirstOrDefaultAsync(t => t.Id == id);
            if (table == null)
                return false;

            _appDbContext.Tables.Remove(table);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        // public void ToggleTable(int id)
        // {
        //     Table? table = GetTable(id);
        //     if (table != null)
        //     {
        //         if (table.Status == TableStatus.Free)
        //         {
        //             table.Status = TableStatus.Occupied;
        //             table.OrderNumber = new Random().Next(1000, 9999);
        //         }
        //         else if (table.Status != TableStatus.Free)
        //         {
        //             table.Status = TableStatus.Free;
        //             table.OrderNumber = 0;
        //         }
        //     }
        // }
    }
}
