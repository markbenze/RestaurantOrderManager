using RestaurantOrderManager.Models;

namespace RestaurantOrderManager.Services;

public class MenuService
{
    private List<MenuItem> Menu { get; set; } = new List<MenuItem>()
    {
        new MenuItem
        {
            Id = 1, Name = "Margherita Pizza", Price = 8.99m,
            Description = "Classic pizza with tomato sauce, mozzarella, and basil."
        },
        new MenuItem
        {
            Id = 2, Name = "Caesar Salad", Price = 6.49m,
            Description = "Crisp romaine lettuce with Caesar dressing, croutons, and Parmesan cheese."
        },
        new MenuItem
        {
            Id = 3, Name = "Spaghetti Carbonara", Price = 10.99m,
            Description = "Pasta with eggs, cheese, pancetta, and pepper."
        },
        new MenuItem
        {
            Id = 4, Name = "Grilled Chicken Sandwich", Price = 7.99m,
            Description = "Grilled chicken breast with lettuce, tomato, and mayo on a toasted bun."
        },
        new MenuItem
        {
            Id = 5, Name = "Chocolate Lava Cake", Price = 5.49m,
            Description = "Warm chocolate cake with a gooey chocolate center."
        }
    };
    
    public MenuItem? GetMenuItem(int id)
    {
        return Menu.FirstOrDefault(p => p.Id == id);
    }
}