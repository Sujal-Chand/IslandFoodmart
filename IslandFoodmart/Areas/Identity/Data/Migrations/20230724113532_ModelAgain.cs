using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IslandFoodmart.Data.Migrations
{
    public partial class ModelAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "ShoppingOrder",
                newName: "PriceTotal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PriceTotal",
                table: "ShoppingOrder",
                newName: "TotalPrice");
        }
    }
}
