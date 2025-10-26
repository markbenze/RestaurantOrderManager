using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantOrderManager.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedOrdersOrderItemFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuItemId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
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

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    MenuItemId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_OrderId",
                table: "CartItem",
                column: "OrderId");
        }
    }
}
