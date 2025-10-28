using RestaurantOrderManager.Shared.Models;

namespace RestaurantOrderManager.Client.Pages
{
    public partial class UserEditor
    {
        private List<User> users;
        private User newUser = new();
        private string errorMessage;

        protected override async Task OnInitializedAsync()
        {
            await LoadUsers();
        }

        private async Task LoadUsers()
        {
            try
            {
                users = await UserService.GetUsersAsync();
            }
            catch
            {
                errorMessage = "Failed to load users.";
            }
        }

        private async Task AddUser()
        {
            try
            {
                await UserService.AddUserAsync(newUser);
                newUser = new();
                await LoadUsers();
            }
            catch
            {
                errorMessage = "Failed to add user.";
            }
        }

        private async Task RemoveUser(int id)
        {
            try
            {
                await UserService.RemoveUserAsync(id);
                await LoadUsers();
            }
            catch
            {
                errorMessage = "Failed to remove user.";
            }
        }
    }
}
