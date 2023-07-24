using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IslandFoodmart.Data.Migrations
{
    public partial class ModelAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingOrder_AspNetUsers_DatabaseUserId",
                table: "ShoppingOrder");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingOrder_DatabaseUserId",
                table: "ShoppingOrder");

            migrationBuilder.DropColumn(
                name: "DatabaseUserId",
                table: "ShoppingOrder");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ShoppingOrder");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ShoppingCart");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "ShoppingOrder",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "ShoppingOrder");

            migrationBuilder.AddColumn<string>(
                name: "DatabaseUserId",
                table: "ShoppingOrder",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ShoppingOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ShoppingCart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingOrder_DatabaseUserId",
                table: "ShoppingOrder",
                column: "DatabaseUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingOrder_AspNetUsers_DatabaseUserId",
                table: "ShoppingOrder",
                column: "DatabaseUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
