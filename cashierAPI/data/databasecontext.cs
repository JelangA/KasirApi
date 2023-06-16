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
        //akuncs
        modelBuilder.Entity<AkunCS>()
            .HasKey(a => a.id_akun);

        //konsumen
        modelBuilder.Entity<Konsumen>()
            .HasKey(k => k.id_konsumen);


        //closing
        modelBuilder.Entity<Closing>()
            .HasKey(c => c.id_closing);

        //product
        modelBuilder.Entity<Product>()
            .HasKey(p => p.id_product);

        //variant
        modelBuilder.Entity<Variant>()
            .HasKey(v => v.id_variant);
    }

    public DbSet<cashierAPI.Models.Product> Product { get; set; } = default!;

    public DbSet<cashierAPI.Models.Variant> Variant { get; set; } = default!;

    public DbSet<cashierAPI.Models.Closing> Closing { get; set; } = default!;
}