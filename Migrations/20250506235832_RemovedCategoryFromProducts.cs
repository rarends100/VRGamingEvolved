using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VRGamingEvolved.Migrations
{
    public partial class RemovedCategoryFromProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "Category",
                value: "Game");
        }
    }
}
