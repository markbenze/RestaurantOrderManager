using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Api.Services
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByUsernameAsync(string username);
        Task<User> AddUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
    }
}
