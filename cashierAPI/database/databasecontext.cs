using cashierAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace cashierAPI.database
{
    public class DatabaseContext : DbContext
    {

        public DbSet<Closing> Closings { get; set; } = null!;
        public DbSet<Variant> Variants { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<User> users {  get; set; } = null!;
        public DbSet<AkunCs> AkunCs {  get; set; } = null!;
        
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasOne(e => e.AkunCs)
                .WithOne(e => e.User)
                .HasForeignKey<AkunCs>(e => e.id_user);

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

