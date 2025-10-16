using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Api.Services
{
    public interface IMenuService
    {
        List<MenuItem> GetMenu();
        MenuItem? GetMenuItem(int id);
    }
}
