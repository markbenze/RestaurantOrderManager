using Microsoft.EntityFrameworkCore;
using RestaurantOrderManager.Api.Data;
using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Api.Services.Implementations
{
    public class MenuService: IMenuService
    {
        private readonly RestaurantDbContext _appDbContext;

        public MenuService(RestaurantDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<MenuItem?> GetMenuItemAsync(int id)
        {
            return await _appDbContext.MenuItems.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<MenuItem>> GetMenuAsync()
        {
            return await _appDbContext.MenuItems.ToListAsync();
        }

        //private List<MenuItem> _menu { get; set; } = new List<MenuItem>()
        //{
        //    new MenuItem
        //    {
        //        Id = 1, Name = "Margherita Pizza", Price = 8.99m,
        //        Description = "Classic pizza with tomato sauce, mozzarella, and basil."
        //    },
        //    new MenuItem
        //    {
        //        Id = 2, Name = "Caesar Salad", Price = 6.49m,
        //        Description = "Crisp romaine lettuce with Caesar dressing, croutons, and Parmesan cheese."
        //    },
        //    new MenuItem
        //    {
        //        Id = 3, Name = "Spaghetti Carbonara", Price = 10.99m,
        //        Description = "Pasta with eggs, cheese, pancetta, and pepper."
        //    },
        //    new MenuItem
        //    {
        //        Id = 4, Name = "Grilled Chicken Sandwich", Price = 7.99m,
        //        Description = "Grilled chicken breast with lettuce, tomato, and mayo on a toasted bun."
        //    },
        //    new MenuItem
        //    {
        //        Id = 5, Name = "Chocolate Lava Cake", Price = 5.49m,
        //        Description = "Warm chocolate cake with a gooey chocolate center."
        //    }
        //};
    }
}
