using Microsoft.EntityFrameworkCore;
using RecipesShare.DAL.Abstractions;
using RecipesShare.DAL.Context;
using RecipesShare.DAL.Entities;

namespace RecipesShare.DAL.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipesShareDbContext _context;
        public RecipeRepository(RecipesShareDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddRecipeAsync(Recipe recipe)
        {
            await _context.AddAsync(recipe);
            var affectedRows = await _context.SaveChangesAsync();
            return affectedRows;
        }

        public async Task<int> DeleteRecipeAsync(Recipe recipe)
        {
            _context.Recipes.Remove(recipe);
            var affectedRows = await _context.SaveChangesAsync();
            return affectedRows;
        }

        public async Task<List<Recipe>> GetAllRecipesAsync()
        {
            return await _context.Recipes.ToListAsync();
        }

        public async Task<Recipe?> GetRecipeByIdAsync(int id)
        {
            return await _context.Recipes.FindAsync(id);
        }

        public async Task<int> UpdateRecipeAsync(Recipe recipe)
        {
            _context.Recipes.Update(recipe);
            var affectedRows = await _context.SaveChangesAsync();
            return affectedRows;
        }
    }
}
