using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cashierAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    idproduct = table.Column<int>(name: "id_product", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    jenisproduct = table.Column<string>(name: "jenis_product", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    namaproduct = table.Column<string>(name: "nama_product", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    hargasatuan = table.Column<int>(name: "harga_satuan", type: "int", nullable: false),
                    totalstok = table.Column<int>(name: "total_stok", type: "int", nullable: false),
                    deskripsi = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.idproduct);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Variants",
                columns: table => new
                {
                    idvariant = table.Column<int>(name: "id_variant", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    namavariant = table.Column<string>(name: "nama_variant", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    hargatambahan = table.Column<int>(name: "harga_tambahan", type: "int", nullable: false),
                    stok = table.Column<int>(type: "int", nullable: false),
                    keterangan = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    expireddate = table.Column<DateTime>(name: "expired_date", type: "datetime(6)", nullable: false),
                    productid = table.Column<int>(name: "product_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variants", x => x.idvariant);
                    table.ForeignKey(
                        name: "FK_Variants_Products_product_id",
                        column: x => x.productid,
                        principalTable: "Products",
                        principalColumn: "id_product",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Closings",
                columns: table => new
                {
                    idclosing = table.Column<int>(name: "id_closing", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    alamatpegiriman = table.Column<string>(name: "alamat_pegiriman", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<int>(type: "int", nullable: false),
                    totalharga = table.Column<int>(name: "total_harga", type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    variantid = table.Column<int>(name: "variant_id", type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Closings", x => x.idclosing);
                    table.ForeignKey(
                        name: "FK_Closings_Variants_variant_id",
                        column: x => x.variantid,
                        principalTable: "Variants",
                        principalColumn: "id_variant",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Closings_variant_id",
                table: "Closings",
                column: "variant_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Variants_product_id",
                table: "Variants",
                column: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Closings");

            migrationBuilder.DropTable(
                name: "Variants");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
