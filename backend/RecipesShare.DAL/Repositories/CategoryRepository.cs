using Microsoft.EntityFrameworkCore;
using RecipesShare.DAL.Abstractions;
using RecipesShare.DAL.Context;
using RecipesShare.DAL.Entities;

namespace RecipesShare.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly RecipesShareDbContext _context;
        public CategoryRepository(RecipesShareDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddCategoryAsync(Category category)
        {
            await _context.AddAsync(category);
            var affectedRows = await _context.SaveChangesAsync();
            return affectedRows;
        }

        public async Task<int> DeleteCategoryAsync(Category category)
        {
            _context.Categories.Remove(category);
            var affectedRows = await _context.SaveChangesAsync();
            return affectedRows;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<int> UpdateCategoryAsync(Category category)
        {
            _context.Categories.Update(category);
            var affectedRows = await _context.SaveChangesAsync();
            return affectedRows;
        }
    }
}
