using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectroShop.Infrasctures.Data.Ef.Migrations
{
    public partial class addquntityorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Quntity",
                table: "Orders",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quntity",
                table: "Orders");
        }
    }
}
