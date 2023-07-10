using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsDomasna.Data.Migrations
{
    /// <inheritdoc />
    public partial class madinj16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Carts_ShoppingCartCartId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Carts_ShoppingCartCartId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ShoppingCartCartId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ShoppingCartCartId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ShoppingCartCartId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "ShoppingCartCartId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    ShoppingCartItemId = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => new { x.ShoppingCartItemId, x.ShoppingCartId, x.TicketId });
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Carts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ShoppingCartId",
                table: "ShoppingCartItems",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_TicketId",
                table: "ShoppingCartItems",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_UserId",
                table: "Carts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_UserId",
                table: "Carts");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_Carts_UserId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Carts");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartCartId",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartCartId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ShoppingCartCartId",
                table: "Tickets",
                column: "ShoppingCartCartId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ShoppingCartCartId",
                table: "AspNetUsers",
                column: "ShoppingCartCartId");

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
    }
}
