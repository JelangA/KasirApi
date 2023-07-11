using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cashierAPI.Migrations
{
    /// <inheritdoc />
    public partial class pertama : Migration
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
                name: "users",
                columns: table => new
                {
                    iduser = table.Column<int>(name: "id_user", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    namauser = table.Column<string>(name: "nama_user", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    gender = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    notelpon = table.Column<string>(name: "no_telpon", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    alamat = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.iduser);
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
                name: "AkunCs",
                columns: table => new
                {
                    idakunCs = table.Column<int>(name: "id_akunCs", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userid = table.Column<int>(name: "user_id", type: "int", nullable: false),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AkunCs", x => x.idakunCs);
                    table.ForeignKey(
                        name: "FK_AkunCs_users_user_id",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "konsumens",
                columns: table => new
                {
                    idKonsumen = table.Column<int>(name: "id_Konsumen", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AkunCsid = table.Column<int>(name: "AkunCs_id", type: "int", nullable: false),
                    namakonsumen = table.Column<string>(name: "nama_konsumen", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    kontak = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_konsumens", x => x.idKonsumen);
                    table.ForeignKey(
                        name: "FK_konsumens_AkunCs_AkunCs_id",
                        column: x => x.AkunCsid,
                        principalTable: "AkunCs",
                        principalColumn: "id_akunCs",
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
                    konsumenid = table.Column<int>(name: "konsumen_id", type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Closings_konsumens_konsumen_id",
                        column: x => x.konsumenid,
                        principalTable: "konsumens",
                        principalColumn: "id_Konsumen");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AkunCs_user_id",
                table: "AkunCs",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Closings_konsumen_id",
                table: "Closings",
                column: "konsumen_id");

            migrationBuilder.CreateIndex(
                name: "IX_Closings_variant_id",
                table: "Closings",
                column: "variant_id");

            migrationBuilder.CreateIndex(
                name: "IX_konsumens_AkunCs_id",
                table: "konsumens",
                column: "AkunCs_id",
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
                name: "konsumens");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AkunCs");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
