using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsDomasna.Data.Migrations
{
    /// <inheritdoc />
    public partial class mea123312 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Tickets");
        }
    }
}
