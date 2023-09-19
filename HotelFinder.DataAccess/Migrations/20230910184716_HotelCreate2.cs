using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelFinder.DataAccess.Migrations
{
    public partial class HotelCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "City", "Name" },
                values: new object[] { 1, "İstanbul", "Hilton" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "City", "Name" },
                values: new object[] { 2, "Ankara", "Pasha Hotel" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
