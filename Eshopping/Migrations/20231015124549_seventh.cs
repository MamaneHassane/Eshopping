using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eshopping.Migrations
{
    public partial class seventh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SearchString",
                table: "Stock");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SearchString",
                table: "Stock",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
