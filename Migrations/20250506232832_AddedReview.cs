using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VRGamingEvolved.Migrations
{
    public partial class AddedReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Review",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "Review",
                value: "This game is awesome!");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Review",
                table: "products");
        }
    }
}
