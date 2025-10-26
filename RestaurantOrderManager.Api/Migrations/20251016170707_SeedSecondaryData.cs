using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantOrderManager.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedSecondaryData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[] { 6, "Piciburgir", "Sajtburger", 1.0m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
