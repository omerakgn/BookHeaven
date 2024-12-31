using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookHeaven.Repository.Migrations
{
    /// <inheritdoc />
    public partial class migration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Storage",
                table: "Files");

            migrationBuilder.CreateTable(
                name: "BookProductImage",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    ProductImagesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookProductImage", x => new { x.BooksId, x.ProductImagesId });
                    table.ForeignKey(
                        name: "FK_BookProductImage_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookProductImage_Files_ProductImagesId",
                        column: x => x.ProductImagesId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookProductImage_ProductImagesId",
                table: "BookProductImage",
                column: "ProductImagesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookProductImage");

            migrationBuilder.AddColumn<string>(
                name: "Storage",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
