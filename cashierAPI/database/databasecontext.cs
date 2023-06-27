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

        public DbSet<Closing> Closings { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>()
                .HasMany(e => e.variants)
                .WithOne(e => e.product)
                .HasForeignKey(e => e.product_id);

            modelBuilder.Entity<Variant>()
                .HasOne(e => e.closing)
                .WithOne(e => e.variant)
                .HasForeignKey<Closing>(e => e.variant_id);

            base.OnModelCreating(modelBuilder);
            
        }
    }
}

