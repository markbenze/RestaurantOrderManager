using RestaurantOrderManager.Models;

namespace RestaurantOrderManager.Services;

public class TableService
{
    public List<Table> Tables = new List<Table>()
    {
        new Table { Id = 1, OrderNumber = 0, State = TableState.Reserved },
        new Table { Id = 2, OrderNumber = 0, State = TableState.Free },
        new Table { Id = 3, OrderNumber = 0, State = TableState.Free },
        new Table { Id = 4, OrderNumber = 0, State = TableState.Occupied },
        new Table { Id = 5, OrderNumber = 0, State = TableState.Free },
        new Table { Id = 6, OrderNumber = 0, State = TableState.Reserved },
        new Table { Id = 7, OrderNumber = 0, State = TableState.Free },
        new Table { Id = 8, OrderNumber = 0, State = TableState.Reserved },
        new Table { Id = 9, OrderNumber = 0, State = TableState.Free },
        new Table { Id = 10, OrderNumber = 0, State = TableState.Free }
    };

    public List<Table> GetTables()
    {
        return Tables;
    }

    public Table? GetTable(int id)
    {
        return Tables.FirstOrDefault(t => t.Id == id);
    }

    public void ToggleTable(int id)
    {
        Table? table = GetTable(id);
        if (table != null)
        {
            if (table.State == TableState.Free)
            {
                table.State = TableState.Occupied;
                table.OrderNumber = new Random().Next(1000, 9999);
            }
            else if (table.State != TableState.Free)
            {
                table.State = TableState.Free;
                table.OrderNumber = 0;
            }
        }
    }
}