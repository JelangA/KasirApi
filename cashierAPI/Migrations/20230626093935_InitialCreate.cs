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
                    jenisproduct = table.Column<int>(name: "jenis_product", type: "int", nullable: false),
                    namaproduct = table.Column<string>(name: "nama_product", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
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

            migrationBuilder.CreateIndex(
                name: "IX_Variants_product_id",
                table: "Variants",
                column: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Variants");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
