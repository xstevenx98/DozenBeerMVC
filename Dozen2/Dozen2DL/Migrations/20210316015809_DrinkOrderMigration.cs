using Microsoft.EntityFrameworkCore.Migrations;

namespace Dozen2DL.Migrations
{
    public partial class DrinkOrderMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Drinks_DrinkId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DrinkId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DrinkId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DrinkName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "DrinkId", "ABV", "DrinkName", "Price" },
                values: new object[,]
                {
                    { 1, 6, "Lager", 5.00m },
                    { 2, 9, "Ale", 8.00m },
                    { 3, 12, "Stout", 10.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "DrinkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "DrinkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "DrinkId",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "DrinkId",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DrinkName",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DrinkId",
                table: "Orders",
                column: "DrinkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Drinks_DrinkId",
                table: "Orders",
                column: "DrinkId",
                principalTable: "Drinks",
                principalColumn: "DrinkId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
