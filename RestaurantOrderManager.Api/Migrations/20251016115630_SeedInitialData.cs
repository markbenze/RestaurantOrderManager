using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantOrderManager.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Classic pizza with tomato sauce, mozzarella, and basil.", "Margherita Pizza", 8.99m },
                    { 2, "Crisp romaine lettuce with Caesar dressing, croutons, and Parmesan cheese.", "Caesar Salad", 6.49m },
                    { 3, "Pasta with eggs, cheese, pancetta, and pepper.", "Spaghetti Carbonara", 10.99m },
                    { 4, "Grilled chicken breast with lettuce, tomato, and mayo on a toasted bun.", "Grilled Chicken Sandwich", 7.99m },
                    { 5, "Warm chocolate cake with a gooey chocolate center.", "Chocolate Lava Cake", 5.49m }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "OrderNumber", "Status" },
                values: new object[,]
                {
                    { 1, 0, 0 },
                    { 2, 0, 0 },
                    { 3, 0, 0 },
                    { 4, 0, 0 },
                    { 5, 0, 0 },
                    { 6, 0, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
