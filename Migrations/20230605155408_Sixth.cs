using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CargoManagerSystem.Migrations
{
    /// <inheritdoc />
    public partial class Sixth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CargoOderDetails_CargoOrders_CargoorderId",
                table: "CargoOderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CargoOrders_CargoCategories_CargoCategoryId",
                table: "CargoOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_CargoOrders_Customers_CustomerId",
                table: "CargoOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Cities_CityId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Cities_CityId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CityId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CityId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Cities_StateId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_CargoOrders_CargoCategoryId",
                table: "CargoOrders");

            migrationBuilder.DropIndex(
                name: "IX_CargoOrders_CustomerId",
                table: "CargoOrders");

            migrationBuilder.DropIndex(
                name: "IX_CargoOderDetails_CargoorderId",
                table: "CargoOderDetails");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CargoCategoryId",
                table: "CargoOrders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CargoCategoryId",
                table: "CargoOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CityId",
                table: "Employees",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CityId",
                table: "Customers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoOrders_CargoCategoryId",
                table: "CargoOrders",
                column: "CargoCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoOrders_CustomerId",
                table: "CargoOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoOderDetails_CargoorderId",
                table: "CargoOderDetails",
                column: "CargoorderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CargoOderDetails_CargoOrders_CargoorderId",
                table: "CargoOderDetails",
                column: "CargoorderId",
                principalTable: "CargoOrders",
                principalColumn: "CargoorderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CargoOrders_CargoCategories_CargoCategoryId",
                table: "CargoOrders",
                column: "CargoCategoryId",
                principalTable: "CargoCategories",
                principalColumn: "CargoCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CargoOrders_Customers_CustomerId",
                table: "CargoOrders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities",
                column: "StateId",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Cities_CityId",
                table: "Customers",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Cities_CityId",
                table: "Employees",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
