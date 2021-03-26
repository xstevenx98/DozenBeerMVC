using Microsoft.EntityFrameworkCore.Migrations;

namespace Dozen2DL.Migrations
{
    public partial class addInventory2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "InventoryID", "DrinkID", "LocationID", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 50 },
                    { 2, 1, 2, 50 },
                    { 3, 1, 3, 50 },
                    { 4, 2, 1, 50 },
                    { 5, 2, 2, 50 },
                    { 6, 2, 3, 50 },
                    { 7, 3, 1, 50 },
                    { 8, 3, 2, 50 },
                    { 9, 3, 3, 50 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "InventoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "InventoryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "InventoryID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "InventoryID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "InventoryID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "InventoryID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "InventoryID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "InventoryID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "InventoryID",
                keyValue: 9);
        }
    }
}
