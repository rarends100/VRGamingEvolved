using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VRGamingEvolved.Data.Migrations
{
    public partial class SeededAGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "GameId", "GameDescription", "GameName", "GameVersion" },
                values: new object[] { 1, "Gorillas Playing Tag", "Gorilla Tag", "2.0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "GameId",
                keyValue: 1);
        }
    }
}
