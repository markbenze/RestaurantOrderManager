namespace RestaurantOrderManager.Models;

public class CartItem
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; } = 1;
    
    public decimal Total => Price * Quantity;
}