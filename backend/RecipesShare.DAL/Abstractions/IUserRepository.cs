using RecipesShare.DAL.Entities;

namespace RecipesShare.DAL.Abstractions
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByEmailAsync(string email);
        Task<int> AddUserAsync(User user);
        Task<int> DeleteUserAsync(User user);
        Task<int> UpdateUserAsync(User user);
    }
}
