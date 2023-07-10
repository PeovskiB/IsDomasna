using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsDomasna.Data.Migrations
{
    /// <inheritdoc />
    public partial class fim3142241513 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ShoppingCart_ShoppingCartCartId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ShoppingCart_ShoppingCartCartId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart");

            migrationBuilder.RenameTable(
                name: "ShoppingCart",
                newName: "Carts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Carts_ShoppingCartCartId",
                table: "AspNetUsers",
                column: "ShoppingCartCartId",
                principalTable: "Carts",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Carts_ShoppingCartCartId",
                table: "Tickets",
                column: "ShoppingCartCartId",
                principalTable: "Carts",
                principalColumn: "CartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Carts_ShoppingCartCartId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Carts_ShoppingCartCartId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "ShoppingCart");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ShoppingCart_ShoppingCartCartId",
                table: "AspNetUsers",
                column: "ShoppingCartCartId",
                principalTable: "ShoppingCart",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ShoppingCart_ShoppingCartCartId",
                table: "Tickets",
                column: "ShoppingCartCartId",
                principalTable: "ShoppingCart",
                principalColumn: "CartId");
        }
    }
}
