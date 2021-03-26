using Microsoft.EntityFrameworkCore.Migrations;

namespace Dozen2DL.Migrations
{
    public partial class LocationTableMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationID", "LocationName", "State" },
                values: new object[,]
                {
                    { 1, "Location1", "NY" },
                    { 2, "Location2", "FL" },
                    { 3, "Location3", "VA" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationID",
                keyValue: 3);
        }
    }
}
