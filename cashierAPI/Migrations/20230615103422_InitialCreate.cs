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
                name: "AkunCS",
                columns: table => new
                {
                    idakun = table.Column<int>(name: "id_akun", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nama = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    notlp = table.Column<string>(name: "no_tlp", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    alamat = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    gender = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AkunCS", x => x.idakun);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Closing",
                columns: table => new
                {
                    idclosing = table.Column<int>(name: "id_closing", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    namabarang = table.Column<string>(name: "nama_barang", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    namaakuncs = table.Column<string>(name: "nama_akun_cs", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    jenisbarang = table.Column<int>(name: "jenis_barang", type: "int", nullable: false),
                    idbarang = table.Column<int>(name: "id_barang", type: "int", nullable: false),
                    idakuncs = table.Column<int>(name: "id_akun_cs", type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    alamatpengiriman = table.Column<string>(name: "alamat_pengiriman", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<int>(type: "int", nullable: false),
                    buktitransfer = table.Column<string>(name: "bukti_transfer", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    namakonsumen = table.Column<string>(name: "nama_konsumen", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idkonsumen = table.Column<int>(name: "id_konsumen", type: "int", nullable: false),
                    variant = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idvariant = table.Column<int>(name: "id_variant", type: "int", nullable: false),
                    createdat = table.Column<string>(name: "created_at", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    updatedat = table.Column<string>(name: "updated_at", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    totalharga = table.Column<int>(name: "total_harga", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Closing", x => x.idclosing);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Konsumen",
                columns: table => new
                {
                    idkonsumen = table.Column<int>(name: "id_konsumen", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idakun = table.Column<int>(name: "id_akun", type: "int", nullable: false),
                    namaakuncs = table.Column<string>(name: "nama_akun_cs", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    namakonsumen = table.Column<string>(name: "nama_konsumen", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    kontak = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konsumen", x => x.idkonsumen);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    idproduct = table.Column<int>(name: "id_product", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    namaproduct = table.Column<string>(name: "nama_product", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    jenisbarang = table.Column<int>(name: "jenis_barang", type: "int", nullable: false),
                    harga = table.Column<int>(type: "int", nullable: false),
                    totalstock = table.Column<int>(name: "total_stock", type: "int", nullable: false),
                    deskripsi = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.idproduct);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Variant",
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
                    Productidproduct = table.Column<int>(name: "Productid_product", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variant", x => x.idvariant);
                    table.ForeignKey(
                        name: "FK_Variant_Product_Productid_product",
                        column: x => x.Productidproduct,
                        principalTable: "Product",
                        principalColumn: "id_product");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Variant_Productid_product",
                table: "Variant",
                column: "Productid_product");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AkunCS");

            migrationBuilder.DropTable(
                name: "Closing");

            migrationBuilder.DropTable(
                name: "Konsumen");

            migrationBuilder.DropTable(
                name: "Variant");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
