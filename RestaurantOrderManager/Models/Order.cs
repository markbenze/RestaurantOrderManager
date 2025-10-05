namespace RestaurantOrderManager.Models;

public class Order
{
    public int Id { get; set; }
    public int TableId { get; set; }
    public decimal Total { get; set; }
    public OrderState State { get; set; }
    public List<CartItem> CartItems { get; set; } = new();
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

public enum OrderState
{
    Pending,
    InProgress,
    Completed,
    Cancelled
}