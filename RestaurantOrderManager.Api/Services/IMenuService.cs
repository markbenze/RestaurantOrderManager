using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Api.Services
{
    public interface IMenuService
    {
        Task<List<MenuItem>> GetMenuAsync();
        Task<MenuItem?> GetMenuItemAsync(int id);
        Task<MenuItem> AddMenuItemAsync(MenuItem item);
        Task<bool> RemoveMenuItemAsync(int id);
    }
}
