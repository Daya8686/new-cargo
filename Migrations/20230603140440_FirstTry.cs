using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CargoManagerSystem.Migrations
{
    /// <inheritdoc />
    public partial class FirstTry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CargoCategories",
                columns: table => new
                {
                    CargoCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoCategoryType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoCategories", x => x.CargoCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CustomerZip = table.Column<int>(type: "int", nullable: false),
                    CargooderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeFName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeLName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfResign = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "CargoOrders",
                columns: table => new
                {
                    CargoorderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoOrders", x => x.CargoorderId);
                    table.ForeignKey(
                        name: "FK_CargoOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CargoOderDetails",
                columns: table => new
                {
                    CargoorderDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoorderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ToCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoorderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoOderDetails", x => x.CargoorderDetailsId);
                    table.ForeignKey(
                        name: "FK_CargoOderDetails_CargoOrders_CargoorderId",
                        column: x => x.CargoorderId,
                        principalTable: "CargoOrders",
                        principalColumn: "CargoorderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoorderDetailsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_CargoOderDetails_CargoorderDetailsId",
                        column: x => x.CargoorderDetailsId,
                        principalTable: "CargoOderDetails",
                        principalColumn: "CargoorderDetailsId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CargoOderDetails_CargoorderId",
                table: "CargoOderDetails",
                column: "CargoorderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CargoOrders_CustomerId",
                table: "CargoOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CargoorderDetailsId",
                table: "Cities",
                column: "CargoorderDetailsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CargoCategories");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "CargoOderDetails");

            migrationBuilder.DropTable(
                name: "CargoOrders");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
