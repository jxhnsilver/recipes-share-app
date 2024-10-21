using Microsoft.EntityFrameworkCore;
using RecipesShare.DAL.Abstractions;
using RecipesShare.DAL.Context;
using RecipesShare.DAL.Entities;

namespace RecipesShare.DAL.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RecipesShareDbContext _context;
        public RoleRepository(RecipesShareDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddRoleAsync(Role role)
        {
            await _context.AddAsync(role);
            var affectedRows = await _context.SaveChangesAsync();
            return affectedRows;
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role?> GetRoleByNameAsync(string roleName)
        {
            return await _context.Roles.SingleOrDefaultAsync(r => r.Name == roleName);
        }
    }
}
