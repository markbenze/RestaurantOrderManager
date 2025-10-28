using Microsoft.EntityFrameworkCore;
using RestaurantOrderManager.Api.Data;
using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Api.Services.Implementations
{
    public class UserService: IUserService
    {
        private readonly RestaurantDbContext _appDbContext;

        public UserService(RestaurantDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<User>> GetUsersAsync()
            => await _appDbContext.Users.ToListAsync();

        public async Task<User?> GetUserByIdAsync(int id)
            => await _appDbContext.Users.FindAsync(id);

        public async Task<User?> GetUserByUsernameAsync(string username)
            => await _appDbContext.Users.FirstOrDefaultAsync(u => u.Username == username);

        public async Task<User> AddUserAsync(User user)
        {
            _appDbContext.Users.Add(user);
            await _appDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _appDbContext.Users.FindAsync(id);
            if (user == null) return false;
            _appDbContext.Users.Remove(user);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
    }
}
