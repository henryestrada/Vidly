using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Migrations
{
    /// <inheritdoc />
    public partial class PopulateGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Comedy')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Action')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Family')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Romance')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Genres WHERE Id IN (1, 2, 3, 4)");
        }
    }
}
