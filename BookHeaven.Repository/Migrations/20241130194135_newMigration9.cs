using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookHeaven.Repository.Migrations
{
    /// <inheritdoc />
    public partial class newMigration9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrdImage",
                table: "Books");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrdImage",
                table: "Books",
                type: "nvarchar(250)",
                nullable: false,
                defaultValue: "");
        }
    }
}
