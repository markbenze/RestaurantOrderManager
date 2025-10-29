using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantOrderManager.Api.Migrations
{
    /// <inheritdoc />
    public partial class ReservationsWithName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Reservations");
        }
    }
}
