using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsDomasna.Data.Migrations
{
    /// <inheritdoc />
    public partial class fim3142 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "ShoppingCart");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "ShoppingCart",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
