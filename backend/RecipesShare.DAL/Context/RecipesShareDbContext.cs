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
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                
                entity.HasMany(c => c.Recipes)
                    .WithOne(r => r.Category)
                    .HasForeignKey(r => r.CategoryId);
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.HasKey(r => r.Id);

                entity.HasOne(r => r.Category)
                    .WithMany(c => c.Recipes)
                    .HasForeignKey(r => r.CategoryId);
            });
        }
    }
}
