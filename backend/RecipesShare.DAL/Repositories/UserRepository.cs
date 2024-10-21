using Microsoft.EntityFrameworkCore;
using RecipesShare.DAL.Abstractions;
using RecipesShare.DAL.Context;
using RecipesShare.DAL.Entities;

namespace RecipesShare.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RecipesShareDbContext _context;
        public UserRepository(RecipesShareDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddUserAsync(User user)
        {
            await _context.AddAsync(user);
            var affectedRows = await _context.SaveChangesAsync();
            return affectedRows;
        }

        public async Task<int> DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            var affectedRows = await _context.SaveChangesAsync();
            return affectedRows;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .Include(u => u.UsersRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<int> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            var affectedRows = await _context.SaveChangesAsync();
            return affectedRows;
        }
    }
}
