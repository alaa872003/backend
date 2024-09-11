using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P01_SalesDatabase.Migrations
{
    /// <inheritdoc />
    public partial class SalesAddDateDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sales");
        }
    }
}
