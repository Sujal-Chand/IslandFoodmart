﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IslandFoodmart.Migrations
{
    public partial class OrderStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderStatus",
                table: "ShoppingOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "ShoppingOrder");
        }
    }
}
