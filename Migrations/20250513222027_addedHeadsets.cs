using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VRGamingEvolved.Migrations
{
    public partial class addedHeadsets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HeadsetModel",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductId", "Cost", "Discriminator", "FileName", "GameDescription", "GameVersion", "ProductName", "Review", "Sell" },
                values: new object[] { 2, 10.00m, "Game", "", "Action war shooter with realistic combat physics", "5.0", "Vail VR", "Vail VR is lit!", 30.00m });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductId", "Cost", "Discriminator", "FileName", "HeadsetModel", "ProductName", "Review", "Sell" },
                values: new object[] { 4, 200.00m, "Headset", "", "1.0", "Gaming Evolved Head rig 1", "Whoa bruh, it was realer than reality bruh, rizz fizzbuzz bruh kitty fish fish brainrot0", 350.00m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "HeadsetModel",
                table: "products");
        }
    }
}
