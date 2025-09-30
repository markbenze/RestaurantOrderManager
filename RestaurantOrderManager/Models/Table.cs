namespace RestaurantOrderManager.Models;

public class Table
{
    public int Id { get; set; }
    public int OrderNumber { get; set; }
    public TableState State { get; set; } = TableState.Free;
}

public enum TableState
{
    Free,
    Occupied,
    Reserved
}