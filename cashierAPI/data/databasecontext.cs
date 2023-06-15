using cashierAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace cashierAPI.data;

public class databaseContext : DbContext
{
    public databaseContext(DbContextOptions<databaseContext> options)
        : base(options)
    {
    }

    public DbSet<AkunCS> AkunCS { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AkunCS>()
            .HasKey(a => a.id_akun);
        modelBuilder.Entity<Closing>()
            .HasKey(a => a.id_closing);
        modelBuilder.Entity<Konsumen>()
            .HasKey(a => a.id_konsumen);
        modelBuilder.Entity<Product>()
            .HasKey(a => a.id_product);
        modelBuilder.Entity<Variant>()
            .HasKey(a => a.id_variant);
    }

    public DbSet<cashierAPI.Models.Product> Product { get; set; } = default!;

    public DbSet<cashierAPI.Models.Variant> Variant { get; set; } = default!;

    public DbSet<cashierAPI.Models.Closing> Closing { get; set; } = default!;
}