using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eshopping.Migrations
{
    public partial class nine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Clients_clientId",
                table: "Carts");

            migrationBuilder.DropTable(
                name: "CartProduct");

            migrationBuilder.AlterColumn<int>(
                name: "clientId",
                table: "Carts",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Carts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductId",
                table: "Carts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Clients_clientId",
                table: "Carts",
                column: "clientId",
                principalTable: "Clients",
                principalColumn: "clientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Stock_ProductId",
                table: "Carts",
                column: "ProductId",
                principalTable: "Stock",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Clients_clientId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Stock_ProductId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_ProductId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Carts");

            migrationBuilder.AlterColumn<int>(
                name: "clientId",
                table: "Carts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CartProduct",
                columns: table => new
                {
                    cartscartId = table.Column<int>(type: "INTEGER", nullable: false),
                    productsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProduct", x => new { x.cartscartId, x.productsId });
                    table.ForeignKey(
                        name: "FK_CartProduct_Carts_cartscartId",
                        column: x => x.cartscartId,
                        principalTable: "Carts",
                        principalColumn: "cartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProduct_Stock_productsId",
                        column: x => x.productsId,
                        principalTable: "Stock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_productsId",
                table: "CartProduct",
                column: "productsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Clients_clientId",
                table: "Carts",
                column: "clientId",
                principalTable: "Clients",
                principalColumn: "clientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
