using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IslandFoodmart.Data.Migrations
{
    public partial class FoodmartModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<int>(
                name: "PaymentID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingOrderID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "ShoppingOrder",
                columns: table => new
                {
                    ShoppingOrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PickupDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingOrder", x => x.ShoppingOrderID);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentAmount = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShoppingOrderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payment_ShoppingOrder_ShoppingOrderID",
                        column: x => x.ShoppingOrderID,
                        principalTable: "ShoppingOrder",
                        principalColumn: "ShoppingOrderID");
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    ShoppingCartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    ShoppingOrderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.ShoppingCartID);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_ShoppingOrder_ShoppingOrderID",
                        column: x => x.ShoppingOrderID,
                        principalTable: "ShoppingOrder",
                        principalColumn: "ShoppingOrderID");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<int>(type: "int", nullable: false),
                    ProductStock = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Product_ShoppingCart_ShoppingCartID",
                        column: x => x.ShoppingCartID,
                        principalTable: "ShoppingCart",
                        principalColumn: "ShoppingCartID");
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK_Category_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PaymentID",
                table: "AspNetUsers",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ShoppingCartID",
                table: "AspNetUsers",
                column: "ShoppingCartID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ShoppingOrderID",
                table: "AspNetUsers",
                column: "ShoppingOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ProductID",
                table: "Category",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ShoppingOrderID",
                table: "Payment",
                column: "ShoppingOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ShoppingCartID",
                table: "Product",
                column: "ShoppingCartID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_ShoppingOrderID",
                table: "ShoppingCart",
                column: "ShoppingOrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Payment_PaymentID",
                table: "AspNetUsers",
                column: "PaymentID",
                principalTable: "Payment",
                principalColumn: "PaymentID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ShoppingCart_ShoppingCartID",
                table: "AspNetUsers",
                column: "ShoppingCartID",
                principalTable: "ShoppingCart",
                principalColumn: "ShoppingCartID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ShoppingOrder_ShoppingOrderID",
                table: "AspNetUsers",
                column: "ShoppingOrderID",
                principalTable: "ShoppingOrder",
                principalColumn: "ShoppingOrderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Payment_PaymentID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ShoppingCart_ShoppingCartID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ShoppingOrder_ShoppingOrderID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "ShoppingOrder");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PaymentID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ShoppingCartID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ShoppingOrderID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PaymentID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ShoppingCartID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ShoppingOrderID",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
