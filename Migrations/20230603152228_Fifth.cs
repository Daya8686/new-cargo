using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CargoManagerSystem.Migrations
{
    /// <inheritdoc />
    public partial class Fifth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_CargoOderDetails_CargoorderDetailsId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CargoorderDetailsId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_CargoOderDetails_CargoorderId",
                table: "CargoOderDetails");

            migrationBuilder.DropColumn(
                name: "CargoorderDetailsId",
                table: "Cities");

            migrationBuilder.AddColumn<int>(
                name: "CargoCategoryId",
                table: "CargoOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "CargoOderDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CargoorderId",
                table: "CargoCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CargoOrders_CargoCategoryId",
                table: "CargoOrders",
                column: "CargoCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoOderDetails_CargoorderId",
                table: "CargoOderDetails",
                column: "CargoorderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CargoOrders_CargoCategories_CargoCategoryId",
                table: "CargoOrders",
                column: "CargoCategoryId",
                principalTable: "CargoCategories",
                principalColumn: "CargoCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CargoOrders_CargoCategories_CargoCategoryId",
                table: "CargoOrders");

            migrationBuilder.DropIndex(
                name: "IX_CargoOrders_CargoCategoryId",
                table: "CargoOrders");

            migrationBuilder.DropIndex(
                name: "IX_CargoOderDetails_CargoorderId",
                table: "CargoOderDetails");

            migrationBuilder.DropColumn(
                name: "CargoCategoryId",
                table: "CargoOrders");

            migrationBuilder.DropColumn(
                name: "status",
                table: "CargoOderDetails");

            migrationBuilder.DropColumn(
                name: "CargoorderId",
                table: "CargoCategories");

            migrationBuilder.AddColumn<int>(
                name: "CargoorderDetailsId",
                table: "Cities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CargoorderDetailsId",
                table: "Cities",
                column: "CargoorderDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoOderDetails_CargoorderId",
                table: "CargoOderDetails",
                column: "CargoorderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_CargoOderDetails_CargoorderDetailsId",
                table: "Cities",
                column: "CargoorderDetailsId",
                principalTable: "CargoOderDetails",
                principalColumn: "CargoorderDetailsId");
        }
    }
}
