using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsDomasna.Data.Migrations
{
    /// <inheritdoc />
    public partial class mea123312125125 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ShoppingCart_ShoppingCartId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ShoppingCart_ShoppingCartId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "ShoppingCartId",
                table: "Tickets",
                newName: "ShoppingCartCartId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_ShoppingCartId",
                table: "Tickets",
                newName: "IX_Tickets_ShoppingCartCartId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ShoppingCart",
                newName: "CartId");

            migrationBuilder.RenameColumn(
                name: "ShoppingCartId",
                table: "AspNetUsers",
                newName: "ShoppingCartCartId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_ShoppingCartId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_ShoppingCartCartId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ShoppingCart_ShoppingCartCartId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ShoppingCart_ShoppingCartCartId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "ShoppingCartCartId",
                table: "Tickets",
                newName: "ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_ShoppingCartCartId",
                table: "Tickets",
                newName: "IX_Tickets_ShoppingCartId");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "ShoppingCart",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ShoppingCartCartId",
                table: "AspNetUsers",
                newName: "ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_ShoppingCartCartId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ShoppingCart_ShoppingCartId",
                table: "AspNetUsers",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ShoppingCart_ShoppingCartId",
                table: "Tickets",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "Id");
        }
    }
}
