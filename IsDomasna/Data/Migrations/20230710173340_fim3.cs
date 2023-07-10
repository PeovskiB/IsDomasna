using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsDomasna.Data.Migrations
{
    /// <inheritdoc />
    public partial class fim3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tickets",
                newName: "TicketId");

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "ShoppingCart",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "ShoppingCart");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "Tickets",
                newName: "Id");
        }
    }
}
