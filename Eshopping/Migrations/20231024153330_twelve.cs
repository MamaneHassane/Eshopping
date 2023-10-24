using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eshopping.Migrations
{
    public partial class twelve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Clients_clientId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_clientId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "clientId",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "cartId",
                table: "Carts",
                newName: "CartId");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Clients",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CartProductIds",
                table: "Carts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CartId",
                table: "Clients",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Carts_CartId",
                table: "Clients",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "CartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Carts_CartId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_CartId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CartProductIds",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "Carts",
                newName: "cartId");

            migrationBuilder.AddColumn<int>(
                name: "clientId",
                table: "Carts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_clientId",
                table: "Carts",
                column: "clientId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Clients_clientId",
                table: "Carts",
                column: "clientId",
                principalTable: "Clients",
                principalColumn: "clientId");
        }
    }
}
