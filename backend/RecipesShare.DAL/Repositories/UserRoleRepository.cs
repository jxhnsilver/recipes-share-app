using Microsoft.EntityFrameworkCore;
using RecipesShare.DAL.Abstractions;
using RecipesShare.DAL.Context;
using RecipesShare.DAL.Entities;
using System.Data;

namespace RecipesShare.DAL.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly RecipesShareDbContext _context;
        public UserRoleRepository(RecipesShareDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddToRoleAsync(UserRole userRole)
        {
            await _context.AddAsync(userRole);
            var affectedRows = await _context.SaveChangesAsync();
            return affectedRows;
        }

        public async Task<List<Role>> GetRolesByUserIdAsync(int userId)
        {
            return await _context.UsersRoles
                .Where(ur => ur.UserId == userId)
                .Select(ur => ur.Role)
                .ToListAsync();
        }

        public async Task<List<User>> GetUsersInRoleAsync(int roleId)
        {
            return await _context.UsersRoles
                .Where(ur => ur.RoleId == roleId)
                .Select(ur => ur.User)
                .ToListAsync();
        }
    }
}
