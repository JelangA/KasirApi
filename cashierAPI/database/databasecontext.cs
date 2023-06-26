using cashierAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace cashierAPI.database
{
    public class DatabaseContext : DbContext
    {
        
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Variant> Variants { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>()
                .HasMany(e => e.variants)
                .WithOne(e => e.product)
                .HasForeignKey(e => e.product_id);

            base.OnModelCreating(modelBuilder);
            
        }
    }
}

