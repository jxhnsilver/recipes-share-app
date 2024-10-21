using RecipesShare.DAL.Entities;

namespace RecipesShare.DAL.Abstractions
{
    public interface IUserRoleRepository
    {
        Task<int> AddToRoleAsync(UserRole userRole);
        Task<List<Role>> GetRolesByUserIdAsync(int userId);
        Task<List<User>> GetUsersInRoleAsync(int roleId);
    }
}