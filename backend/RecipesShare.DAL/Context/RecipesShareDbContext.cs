using Microsoft.EntityFrameworkCore;
using RecipesShare.DAL.Entities;

namespace RecipesShare.DAL.Context
{
    public class RecipesShareDbContext : DbContext
    {
        public RecipesShareDbContext(DbContextOptions<RecipesShareDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Recipe> Recipes { get; set; }  
    }
}
