using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobilVize.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Inıtial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Properties");
        }
    }
}
