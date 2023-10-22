using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IslandFoodmart.Migrations
{
    public partial class SpecialPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryID",
                keyValue: 5);

            migrationBuilder.AddColumn<decimal>(
                name: "SpecialPrice",
                table: "Product",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialPrice",
                table: "Product");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Fresh Foods" },
                    { 2, "Frozen Foods" },
                    { 3, "Drinks" },
                    { 4, "Pantry" },
                    { 5, "Personal Care" }
                });
        }
    }
}
