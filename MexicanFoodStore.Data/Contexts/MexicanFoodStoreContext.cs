using MexicanFoodStore.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MexicanFoodStore.Data.Contexts
{
    public class MexicanFoodStoreContext(DbContextOptions<MexicanFoodStoreContext> options) : DbContext(options)
    {
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProductCategory>()
           .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            builder.Entity<Product>()
           .HasMany(p => p.Categories)
           .WithMany(c => c.Products)
           .UsingEntity<ProductCategory>();
        }
    }
}
