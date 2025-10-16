using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Api.Services.Implementations
{
    public class TableService: ITableService
    {
        private List<Table> _tables = new List<Table>()
    {
        new Table { Id = 1, OrderNumber = 0, Status = TableStatus.Reserved },
        new Table { Id = 2, OrderNumber = 0, Status = TableStatus.Free },
        new Table { Id = 3, OrderNumber = 0, Status = TableStatus.Free },
        new Table { Id = 4, OrderNumber = 0, Status = TableStatus.Occupied },
        new Table { Id = 5, OrderNumber = 0, Status = TableStatus.Free },
        new Table { Id = 6, OrderNumber = 0, Status = TableStatus.Reserved },
        new Table { Id = 7, OrderNumber = 0, Status = TableStatus.Free },
        new Table { Id = 8, OrderNumber = 0, Status = TableStatus.Reserved },
        new Table { Id = 9, OrderNumber = 0, Status = TableStatus.Free },
        new Table { Id = 10, OrderNumber = 0, Status = TableStatus.Free },
        new Table { Id = 11, OrderNumber = 0, Status = TableStatus.Free },
        new Table { Id = 12, OrderNumber = 0, Status = TableStatus.Free }
    };

        public List<Table> GetTables()
        {
            return _tables;
        }

        public Table? GetTable(int id)
        {
            return _tables.FirstOrDefault(t => t.Id == id);
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
