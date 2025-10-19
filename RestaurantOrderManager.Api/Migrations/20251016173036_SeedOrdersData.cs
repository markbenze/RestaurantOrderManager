using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantOrderManager.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedOrdersData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Orders_OrderId",
                table: "CartItem");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "CartItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "State", "TableId", "Total" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 16, 19, 0, 35, 736, DateTimeKind.Local).AddTicks(3415), 2, 1, 24.47m },
                    { 2, new DateTime(2025, 10, 16, 19, 15, 35, 736, DateTimeKind.Local).AddTicks(3643), 1, 4, 29.96m },
                    { 3, new DateTime(2025, 10, 16, 19, 25, 35, 736, DateTimeKind.Local).AddTicks(3648), 0, 6, 19.98m },
                    { 4, new DateTime(2025, 10, 16, 19, 20, 35, 736, DateTimeKind.Local).AddTicks(3652), 1, 2, 22.97m },
                    { 5, new DateTime(2025, 10, 16, 18, 45, 35, 736, DateTimeKind.Local).AddTicks(3655), 2, 5, 14.48m }
                });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "Id", "MenuItemId", "Name", "OrderId", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "Margherita Pizza", 1, 8.99m, 2 },
                    { 2, 2, "Caesar Salad", 1, 6.49m, 1 },
                    { 3, 3, "Spaghetti Carbonara", 2, 10.99m, 1 },
                    { 4, 4, "Grilled Chicken Sandwich", 2, 7.99m, 1 },
                    { 5, 5, "Chocolate Lava Cake", 2, 5.49m, 2 },
                    { 6, 1, "Margherita Pizza", 3, 8.99m, 1 },
                    { 7, 3, "Spaghetti Carbonara", 3, 10.99m, 1 },
                    { 8, 2, "Caesar Salad", 4, 6.49m, 2 },
                    { 9, 4, "Grilled Chicken Sandwich", 4, 7.99m, 1 },
                    { 10, 6, "Fruit Juice", 4, 1.50m, 3 },
                    { 11, 5, "Chocolate Lava Cake", 5, 5.49m, 1 },
                    { 12, 7, "Espresso", 5, 2.99m, 3 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Orders_OrderId",
                table: "CartItem",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Orders_OrderId",
                table: "CartItem");

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "CartItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Orders_OrderId",
                table: "CartItem",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
