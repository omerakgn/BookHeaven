using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookHeaven.Repository.Migrations
{
    /// <inheritdoc />
    public partial class firstCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    StockCode = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PrdImage = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookCategori",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    CategoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategori", x => new { x.BooksId, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_BookCategori_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategori_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCategori_CategoriesId",
                table: "BookCategori",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_PersonId",
                table: "Groups",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCategori");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
