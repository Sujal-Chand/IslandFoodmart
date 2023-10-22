using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IslandFoodmart.Migrations
{
    public partial class ProductSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Fresh Foods" },
                    { 2, "Frozen Foods" },
                    { 3, "Drinks" },
                    { 4, "Pantry" },
                    { 5, "Personal Care" },
                    { 6, "Dairy" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductID", "CategoryID", "ImagePath", "ProductName", "ProductPrice", "ProductStock", "SpecialPrice" },
                values: new object[,]
                {
                    { 1, 6, "foodimage_0000_Layer-30.png", "Ben & Jerry's Chocolate Chip Cookie Dough", 12.99m, 9, 0m },
                    { 2, 6, "foodimage_0001_Layer-29.png", "Tip Top Creamy Vanilla 2L", 6.20m, 7, 0m },
                    { 3, 5, "foodimage_0002_Layer-28.png", "Band-Aid", 4m, 20, 0m },
                    { 4, 5, "foodimage_0003_Layer-27.png", "Panadol Paracetamol 500mg", 11.99m, 20, 0m },
                    { 5, 5, "foodimage_0004_Layer-26.png", "Colgate Triple Action 110g", 4.5m, 12, 0m },
                    { 6, 4, "foodimage_0005_Layer-25.png", "Maggi Chicken Moodles 360g", 5m, 10, 0m },
                    { 7, 4, "foodimage_0006_Layer-24.png", "Indomie Instant Noodles 85g", 5.99m, 11, 0m },
                    { 8, 4, "foodimage_0007_Layer-23.png", "Pacific Corned Beef 340g", 9.99m, 15, 0m },
                    { 9, 4, "foodimage_0008_Layer-22.png", "Palm Corned Beef 326g", 10.99m, 9, 0m },
                    { 10, 2, "foodimage_0009_Layer-21.png", "Tegal Whole Chicken 2.3kg", 15.60m, 12, 0m },
                    { 11, 2, "foodimage_0010_Layer-20.png", "New Zealand Peas 1kg", 5.5m, 10, 0m },
                    { 12, 6, "foodimage_0011_Layer-19.png", "UHF Standard Milk 1L", 3.5m, 10, 0m },
                    { 13, 4, "foodimage_0012_Layer-18.png", "Shapes Cheese & Bacon 180g", 4m, 18, 0m },
                    { 14, 5, "foodimage_0013_Layer-17.png", "Toilet Paper 3ply", 18m, 6, 0m },
                    { 15, 5, "foodimage_0014_Layer-16.png", "Toilet Paper 2ply", 14.99m, 7, 0m },
                    { 16, 4, "foodimage_0015_Layer-15.png", "Griffins Cookie Bear H&T", 3m, 6, 0m },
                    { 17, 1, "foodimage_0016_Layer-14.png", "Farmer Brown Dozen Eggs", 12m, 4, 0m },
                    { 18, 1, "foodimage_0017_Layer-13.png", "Tip Top White Toast Bread", 5m, 8, 0m },
                    { 19, 1, "foodimage_0018_Layer-12.png", "Natures Fresh White Toast Bread", 4m, 8, 0m },
                    { 20, 5, "foodimage_0019_Layer-11.png", "Nivea Protect & Moisture Sunscreen 50+SPF", 18.99m, 5, 0m },
                    { 21, 3, "foodimage_0020_Layer-10.png", "Coke Classic 2L", 5.5m, 20, 0m },
                    { 22, 3, "foodimage_0021_Layer-9.png", "Sprite Natural Flavour 2L", 5.5m, 20, 0m },
                    { 23, 3, "foodimage_0022_Layer-8.png", "Coke Classic 440ml", 3.99m, 41, 0m },
                    { 24, 3, "foodimage_0023_Layer-7.png", "V Drink Green 500ml", 5.5m, 30, 0m },
                    { 25, 3, "foodimage_0024_Layer-6.png", "V Drink Greem 250ml", 3.2m, 50, 0m },
                    { 26, 3, "foodimage_0025_Layer-5.png", "V Drink Blue 500ml", 5.5m, 42, 0m },
                    { 27, 6, "foodimage_0026_Layer-4.png", "Meadow Fresh Original Milk 2L", 6.5m, 8, 0m },
                    { 28, 4, "foodimage_0027_Layer-3.png", "Anchor Blue Milk Powder 1kg", 3.5m, 7, 0m },
                    { 29, 6, "foodimage_0028_Layer-2.png", "Anchor Blue Milk 3L", 7m, 20, 0m },
                    { 30, 6, "foodimage_0029_Layer-1.png", "Anchor Blue Milk 2L", 5.5m, 20, 0m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 30);

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

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryID",
                keyValue: 6);
        }
    }
}
