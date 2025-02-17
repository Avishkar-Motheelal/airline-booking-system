using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Airline_Booking_Api.Migrations
{
    /// <inheritdoc />
    public partial class InitFlightStatusSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "flight_statuses",
                columns: new[] { "flight_status_id", "status" },
                values: new object[,]
                {
                    { 1, "Scheduled" },
                    { 2, "Boarding" },
                    { 3, "Departed" },
                    { 4, "Arrived" },
                    { 5, "Cancelled" },
                    { 6, "Delayed" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "flight_statuses",
                keyColumn: "flight_status_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "flight_statuses",
                keyColumn: "flight_status_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "flight_statuses",
                keyColumn: "flight_status_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "flight_statuses",
                keyColumn: "flight_status_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "flight_statuses",
                keyColumn: "flight_status_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "flight_statuses",
                keyColumn: "flight_status_id",
                keyValue: 6);
        }
    }
}
