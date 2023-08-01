using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IslandFoodmart.Migrations
{
    public partial class Productlink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ShoppingItem_ProductID",
                table: "ShoppingItem",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingItem_Product_ProductID",
                table: "ShoppingItem",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingItem_Product_ProductID",
                table: "ShoppingItem");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingItem_ProductID",
                table: "ShoppingItem");
        }
    }
}
