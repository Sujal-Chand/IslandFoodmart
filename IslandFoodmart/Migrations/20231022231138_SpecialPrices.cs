using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IslandFoodmart.Migrations
{
    public partial class SpecialPrices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 5,
                column: "SpecialPrice",
                value: 4m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 6,
                column: "SpecialPrice",
                value: 4.5m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 14,
                column: "SpecialPrice",
                value: 16.99m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 19,
                columns: new[] { "ProductPrice", "SpecialPrice" },
                values: new object[] { 6m, 5.5m });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 20,
                column: "SpecialPrice",
                value: 16.99m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 23,
                column: "SpecialPrice",
                value: 2.99m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 24,
                column: "SpecialPrice",
                value: 4.5m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 26,
                column: "SpecialPrice",
                value: 4.5m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 5,
                column: "SpecialPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 6,
                column: "SpecialPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 14,
                column: "SpecialPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 19,
                columns: new[] { "ProductPrice", "SpecialPrice" },
                values: new object[] { 4m, 0m });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 20,
                column: "SpecialPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 23,
                column: "SpecialPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 24,
                column: "SpecialPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 26,
                column: "SpecialPrice",
                value: 0m);
        }
    }
}
