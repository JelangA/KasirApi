﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cashierAPI.database;

#nullable disable

namespace cashierAPI.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("cashierAPI.Models.Closing", b =>
                {
                    b.Property<int>("id_closing")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("alamat_pegiriman")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<int>("total_harga")
                        .HasColumnType("int");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("variant_id")
                        .HasColumnType("int");

                    b.HasKey("id_closing");

                    b.HasIndex("variant_id")
                        .IsUnique();

                    b.ToTable("Closings");
                });

            modelBuilder.Entity("cashierAPI.Models.Product", b =>
                {
                    b.Property<int>("id_product")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("deskripsi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("harga_satuan")
                        .HasColumnType("int");

                    b.Property<string>("jenis_product")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("nama_product")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("status")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("total_stok")
                        .HasColumnType("int");

                    b.HasKey("id_product");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("cashierAPI.Models.Variant", b =>
                {
                    b.Property<int>("id_variant")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("expired_date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("harga_tambahan")
                        .HasColumnType("int");

                    b.Property<string>("keterangan")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("nama_variant")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("product_id")
                        .HasColumnType("int");

                    b.Property<int>("stok")
                        .HasColumnType("int");

                    b.HasKey("id_variant");

                    b.HasIndex("product_id");

                    b.ToTable("Variants");
                });

            modelBuilder.Entity("cashierAPI.Models.Closing", b =>
                {
                    b.HasOne("cashierAPI.Models.Variant", "variant")
                        .WithOne("closing")
                        .HasForeignKey("cashierAPI.Models.Closing", "variant_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("variant");
                });

            modelBuilder.Entity("cashierAPI.Models.Variant", b =>
                {
                    b.HasOne("cashierAPI.Models.Product", "product")
                        .WithMany("variants")
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");
                });

            modelBuilder.Entity("cashierAPI.Models.Product", b =>
                {
                    b.Navigation("variants");
                });

            modelBuilder.Entity("cashierAPI.Models.Variant", b =>
                {
                    b.Navigation("closing");
                });
#pragma warning restore 612, 618
        }
    }
}
