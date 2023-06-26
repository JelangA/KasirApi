﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cashierAPI.database;

#nullable disable

namespace cashierAPI.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230626093935_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("cashierAPI.Models.Product", b =>
                {
                    b.Property<int>("id_product")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("jenis_product")
                        .HasColumnType("int");

                    b.Property<string>("nama_product")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id_product");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("cashierAPI.Models.Variant", b =>
                {
                    b.Property<int>("id_variant")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nama_variant")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("product_id")
                        .HasColumnType("int");

                    b.HasKey("id_variant");

                    b.HasIndex("product_id");

                    b.ToTable("Variants");
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
#pragma warning restore 612, 618
        }
    }
}
