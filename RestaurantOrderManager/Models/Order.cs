namespace RestaurantOrderManager.Models;

public class Order
{
    public int Id { get; set; }
    public int TableId { get; set; }
    public int Total { get; set; }
    public OrderState State { get; set; }
    public List<MenuItem> MenuItems { get; set; }
}

public enum OrderState
{
    Pending,
    InProgress,
    Completed,
    Cancelled
}