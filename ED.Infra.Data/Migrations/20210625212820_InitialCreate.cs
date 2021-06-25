using Microsoft.EntityFrameworkCore.Migrations;

namespace ED.Infra.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CodCategory = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CodCategory);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    CodGender = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.CodGender);
                });

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    CodAuthor = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    CodCategory = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.CodAuthor);
                    table.ForeignKey(
                        name: "FK_Author_Category_CodCategory",
                        column: x => x.CodCategory,
                        principalTable: "Category",
                        principalColumn: "CodCategory",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Music",
                columns: table => new
                {
                    CodMusic = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CodGender = table.Column<int>(type: "INTEGER", nullable: false),
                    CodAuthor = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Music", x => x.CodMusic);
                    table.ForeignKey(
                        name: "FK_Music_Author_CodAuthor",
                        column: x => x.CodAuthor,
                        principalTable: "Author",
                        principalColumn: "CodAuthor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Music_Gender_CodGender",
                        column: x => x.CodGender,
                        principalTable: "Gender",
                        principalColumn: "CodGender",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Author_CodCategory",
                table: "Author",
                column: "CodCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Music_CodAuthor",
                table: "Music",
                column: "CodAuthor");

            migrationBuilder.CreateIndex(
                name: "IX_Music_CodGender",
                table: "Music",
                column: "CodGender");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Music");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
