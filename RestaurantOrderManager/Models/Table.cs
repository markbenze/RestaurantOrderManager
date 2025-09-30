namespace RestaurantOrderManager.Models;

public class Table
{
    public int Id { get; set; }
    public int OrderNumber { get; set; }
    public TableStatus Status { get; set; } = TableStatus.Free;
}

public enum TableStatus
{
    Free,
    Occupied,
    Reserved
}