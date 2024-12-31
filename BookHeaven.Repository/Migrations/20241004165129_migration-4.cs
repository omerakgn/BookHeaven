using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookHeaven.Repository.Migrations
{
    /// <inheritdoc />
    public partial class migration4 : Migration
    { 
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "Files");
        }
    }
}
