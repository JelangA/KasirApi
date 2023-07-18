using cashierAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace cashierAPI.database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Konsumen> konsumens { get; set; } = null!;  
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
            modelBuilder.Entity<Konsumen>()
                .HasMany(e => e.Closings)
                .WithOne(e => e.konsumen)
                .HasForeignKey(e => e.konsumen_id)
                .IsRequired(false);

            modelBuilder.Entity<AkunCs>()
                .HasOne(e => e.Konsumen)
                .WithOne(e => e.AkunCs)
                .HasForeignKey<Konsumen>(e => e.AkunCs_id)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasOne(e => e.AkunCs)
                .WithOne(e => e.User)
                .HasForeignKey<AkunCs>(e => e.user_id)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .HasMany(e => e.variants)
                .WithOne(e => e.product)
                .HasForeignKey(e => e.product_id);

            modelBuilder.Entity<Variant>()
                .HasMany(v => v.closings) // Relasi one-to-many dari Variant ke Closing
                .WithOne(c => c.variant)
                .HasForeignKey(c => c.variant_id);

            base.OnModelCreating(modelBuilder);
            
        }
    }
}

