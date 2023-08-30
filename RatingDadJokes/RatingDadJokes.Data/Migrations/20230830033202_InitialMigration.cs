using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RatingDadJokes.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JOKES",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Setup = table.Column<string>(type: "TEXT", nullable: false),
                    Punchline = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JOKES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RATINGS",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    JokeId = table.Column<string>(type: "TEXT", nullable: false),
                    Stars = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RATINGS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RATINGS_JOKES_JokeId",
                        column: x => x.JokeId,
                        principalTable: "JOKES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RATINGS_JokeId",
                table: "RATINGS",
                column: "JokeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RATINGS");

            migrationBuilder.DropTable(
                name: "JOKES");
        }
    }
}
