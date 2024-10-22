using RecipesShare.DAL.Entities;

namespace RecipesShare.DAL.Abstractions
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllRolesAsync();
        Task<Role?> GetRoleByNameAsync(string roleName);
        Task<int> AddRoleAsync(Role role);
    }
}
