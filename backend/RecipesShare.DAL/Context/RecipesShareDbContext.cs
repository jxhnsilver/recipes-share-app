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
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UsersRoles { get; set; }

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

                entity.HasOne(r => r.User)
                    .WithMany(u => u.Recipes)
                    .HasForeignKey(r => r.UserId);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(ur => new { ur.UserId, ur.RoleId });

                entity.HasOne(ur => ur.User)
                    .WithMany(u => u.UsersRoles)
                    .HasForeignKey(ur => ur.UserId);

                entity.HasOne(ur => ur.Role)
                    .WithMany(r => r.UsersRoles)
                    .HasForeignKey(ur => ur.RoleId);
            });
        }
    }
}
