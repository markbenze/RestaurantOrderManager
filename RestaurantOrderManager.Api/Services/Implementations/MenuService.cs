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

        public async Task<MenuItem> AddMenuItemAsync(MenuItem item)
        {
            _appDbContext.MenuItems.Add(item);
            await _appDbContext.SaveChangesAsync();
            return item;
        }

        public async Task<bool> RemoveMenuItemAsync(int id)
        {
            var item = await _appDbContext.MenuItems.FindAsync(id);
            if (item == null) return false;
            _appDbContext.MenuItems.Remove(item);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
    }
}
