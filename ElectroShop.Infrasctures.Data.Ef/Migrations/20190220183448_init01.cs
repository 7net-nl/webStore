using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectroShop.Infrasctures.Data.Ef.Migrations
{
    public partial class init01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    ID = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Rate = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    DiscountPrice = table.Column<decimal>(nullable: true),
                    Color = table.Column<string>(nullable: false),
                    Size = table.Column<string>(nullable: false),
                    Category_ID = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Categorys_Category_ID",
                        column: x => x.Category_ID,
                        principalTable: "Categorys",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FileName = table.Column<string>(maxLength: 1000, nullable: false),
                    FileType = table.Column<string>(maxLength: 10, nullable: true),
                    Path = table.Column<string>(maxLength: 2000, nullable: true),
                    Product_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Files_Products_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { (byte)1, "تخفیفات ویژه" },
                    { (byte)2, "لب تاب" },
                    { (byte)3, "موبایل" },
                    { (byte)4, "دوربین" },
                    { (byte)5, "لوازم جانبی" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Category_ID", "Color", "Description", "DiscountPrice", "Price", "Rate", "Size", "Title", "Type" },
                values: new object[,]
                {
                    { 1, (byte)1, "قرمز", "توضیحات کوتاه درباره محصول", 50m, 12000000m, 5, "L", "نام محصول", 2 },
                    { 5, (byte)1, "قرمز", "توضیحات کوتاه درباره محصول", 50m, 999m, 5, "L", "نام محصول", 0 },
                    { 9, (byte)1, "Red", "توضیحات کوتاه درباره محصول", 50m, 999m, 5, "L", "نام محصول", 1 },
                    { 2, (byte)2, "آبی", "توضیحات کوتاه درباره محصول", 30m, 4500000m, 3, "XL", "نام محصول", 2 },
                    { 6, (byte)2, "Blue", "توضیحات کوتاه درباره محصول", 30m, 785m, 3, "XL", "نام محصول", 0 },
                    { 10, (byte)2, "Blue", "توضیحات کوتاه درباره محصول", 30m, 785m, 3, "XL", "نام محصول", 1 },
                    { 3, (byte)3, "قرمز", "توضیحات کوتاه درباره محصول", null, 5000000m, 5, "L", "نام محصول", 2 },
                    { 7, (byte)3, "Red", "توضیحات کوتاه درباره محصول", null, 999m, 5, "L", "نام محصول", 0 },
                    { 11, (byte)3, "Red", "توضیحات کوتاه درباره محصول", null, 999m, 5, "L", "نام محصول", 1 },
                    { 4, (byte)4, "قرمز", "توضیحات کوتاه درباره محصول", null, 999m, 5, "L", "نام محصول", 2 },
                    { 8, (byte)4, "Red", "توضیحات کوتاه درباره محصول", null, 999m, 5, "L", "نام محصول", 0 },
                    { 12, (byte)4, "Red", "توضیحات کوتاه درباره محصول", null, 999m, 5, "L", "نام محصول", 1 }
                });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "ID", "FileName", "FileType", "Path", "Product_ID" },
                values: new object[,]
                {
                    { 1L, "product01.png", null, null, 1 },
                    { 5L, "product01.png", null, null, 5 },
                    { 9L, "product01.png", null, null, 9 },
                    { 2L, "product02.png", null, null, 2 },
                    { 6L, "product02.png", null, null, 6 },
                    { 10L, "product02.png", null, null, 10 },
                    { 3L, "product03.png", null, null, 3 },
                    { 7L, "product03.png", null, null, 7 },
                    { 11L, "product03.png", null, null, 11 },
                    { 4L, "product01.png", null, null, 4 },
                    { 8L, "product01.png", null, null, 8 },
                    { 12L, "product01.png", null, null, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_Product_ID",
                table: "Files",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Category_ID",
                table: "Products",
                column: "Category_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categorys");
        }
    }
}
