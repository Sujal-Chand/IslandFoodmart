using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IslandFoodmart.Data.Migrations
{
    public partial class NewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_Category_Product_ProductID",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_ShoppingOrder_ShoppingOrderID",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ShoppingCart_ShoppingCartID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_ShoppingOrder_ShoppingOrderID",
                table: "ShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_Product_ShoppingCartID",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_ShoppingOrderID",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Category_ProductID",
                table: "Category");

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
                name: "ShoppingCartID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "PaymentID",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "PaymentID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ShoppingCartID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ShoppingOrderID",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "ShoppingCart",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "ShoppingCartID",
                table: "ShoppingCart",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProductImage",
                table: "Product",
                newName: "ImagePath");

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

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "ShoppingOrder",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingOrderID",
                table: "ShoppingCart",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ShoppingCart",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingItemID",
                table: "ShoppingCart",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "ProductPrice",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingOrderID",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PaymentAmount",
                table: "Payment",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart",
                column: "ShoppingItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                table: "Payment",
                column: "ShoppingOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingOrder_DatabaseUserId",
                table: "ShoppingOrder",
                column: "DatabaseUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryID",
                table: "Product",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_ShoppingOrder_ShoppingOrderID",
                table: "Payment",
                column: "ShoppingOrderID",
                principalTable: "ShoppingOrder",
                principalColumn: "ShoppingOrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryID",
                table: "Product",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_ShoppingOrder_ShoppingOrderID",
                table: "ShoppingCart",
                column: "ShoppingOrderID",
                principalTable: "ShoppingOrder",
                principalColumn: "ShoppingOrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingOrder_AspNetUsers_DatabaseUserId",
                table: "ShoppingOrder",
                column: "DatabaseUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_ShoppingOrder_ShoppingOrderID",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_ShoppingOrder_ShoppingOrderID",
                table: "ShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingOrder_AspNetUsers_DatabaseUserId",
                table: "ShoppingOrder");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingOrder_DatabaseUserId",
                table: "ShoppingOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryID",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "DatabaseUserId",
                table: "ShoppingOrder");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ShoppingOrder");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "ShoppingOrder");

            migrationBuilder.DropColumn(
                name: "ShoppingItemID",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "ShoppingCart",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ShoppingCart",
                newName: "ShoppingCartID");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Product",
                newName: "ProductImage");

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingOrderID",
                table: "ShoppingCart",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingCartID",
                table: "ShoppingCart",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ProductPrice",
                table: "Product",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartID",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentAmount",
                table: "Payment",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingOrderID",
                table: "Payment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PaymentID",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Category",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart",
                column: "ShoppingCartID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                table: "Payment",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ShoppingCartID",
                table: "Product",
                column: "ShoppingCartID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ShoppingOrderID",
                table: "Payment",
                column: "ShoppingOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ProductID",
                table: "Category",
                column: "ProductID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Product_ProductID",
                table: "Category",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_ShoppingOrder_ShoppingOrderID",
                table: "Payment",
                column: "ShoppingOrderID",
                principalTable: "ShoppingOrder",
                principalColumn: "ShoppingOrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ShoppingCart_ShoppingCartID",
                table: "Product",
                column: "ShoppingCartID",
                principalTable: "ShoppingCart",
                principalColumn: "ShoppingCartID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_ShoppingOrder_ShoppingOrderID",
                table: "ShoppingCart",
                column: "ShoppingOrderID",
                principalTable: "ShoppingOrder",
                principalColumn: "ShoppingOrderID");
        }
    }
}
