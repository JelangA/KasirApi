using cashierAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace cashierAPI.database
{
    public class databaseContext : DbContext
    {

        DbSet<AkunCS>? akunCCs { set; get; }
        DbSet<Closing>? closings { set; get; }
        DbSet<DetailClosing>? detailClosings { set; get; }
        DbSet<JenisBarang>? jenisBarangs { set; get; }
        DbSet<Konsumen>? Konsumens { set; get; }
        DbSet<Product>? products { set; get; }
        DbSet<Variant>? variants { set; get; }

        public databaseContext(DbContextOptions<databaseContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Product>()
            //     .HasOne(p => p.JenisBarang)
            //     .WithMany()
            //     .HasForeignKey(p => p.jenis_barang_id)
            //     .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

