﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cashierAPI.data;

#nullable disable

namespace cashierAPI.Migrations
{
    [DbContext(typeof(databaseContext))]
    partial class databaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("cashierAPI.Models.AkunCS", b =>
                {
                    b.Property<int>("id_akun")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("alamat")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("nama")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("no_tlp")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("status")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("id_akun");

                    b.ToTable("AkunCS");
                });

            modelBuilder.Entity("cashierAPI.Models.Closing", b =>
                {
                    b.Property<int>("id_closing")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("alamat_pengiriman")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("bukti_transfer")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("created_at")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("id_akun_cs")
                        .HasColumnType("int");

                    b.Property<int>("id_barang")
                        .HasColumnType("int");

                    b.Property<int>("id_konsumen")
                        .HasColumnType("int");

                    b.Property<int>("id_variant")
                        .HasColumnType("int");

                    b.Property<int>("jenis_barang")
                        .HasColumnType("int");

                    b.Property<string>("nama_akun_cs")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("nama_barang")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("nama_konsumen")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<int>("total_harga")
                        .HasColumnType("int");

                    b.Property<string>("updated_at")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("variant")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id_closing");

                    b.ToTable("Closing");
                });

            modelBuilder.Entity("cashierAPI.Models.Konsumen", b =>
                {
                    b.Property<int>("id_konsumen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("id_akun")
                        .HasColumnType("int");

                    b.Property<int>("kontak")
                        .HasColumnType("int");

                    b.Property<string>("nama_akun_cs")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("nama_konsumen")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id_konsumen");

                    b.ToTable("Konsumen");
                });

            modelBuilder.Entity("cashierAPI.Models.Product", b =>
                {
                    b.Property<int>("id_product")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("deskripsi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("harga")
                        .HasColumnType("int");

                    b.Property<int>("jenis_barang")
                        .HasColumnType("int");

                    b.Property<string>("nama_product")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("status")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("total_stock")
                        .HasColumnType("int");

                    b.HasKey("id_product");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("cashierAPI.Models.Variant", b =>
                {
                    b.Property<int>("id_variant")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("Productid_product")
                        .HasColumnType("int");

                    b.Property<int>("harga_tambahan")
                        .HasColumnType("int");

                    b.Property<string>("keterangan")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("nama_variant")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("stok")
                        .HasColumnType("int");

                    b.HasKey("id_variant");

                    b.HasIndex("Productid_product");

                    b.ToTable("Variant");
                });

            modelBuilder.Entity("cashierAPI.Models.Variant", b =>
                {
                    b.HasOne("cashierAPI.Models.Product", null)
                        .WithMany("list_variant")
                        .HasForeignKey("Productid_product");
                });

            modelBuilder.Entity("cashierAPI.Models.Product", b =>
                {
                    b.Navigation("list_variant");
                });
#pragma warning restore 612, 618
        }
    }
}
