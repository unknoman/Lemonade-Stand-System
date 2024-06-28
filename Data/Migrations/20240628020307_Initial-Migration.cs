using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientOrders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientOrders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tel = table.Column<int>(type: "int", nullable: false),
                    suppliesOrder = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    unityPrice = table.Column<float>(type: "real", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stock = table.Column<float>(type: "real", nullable: false),
                    unitMeasure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_type",
                        column: x => x.type,
                        principalTable: "ProductTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuppliesOrders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    supplier = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuppliesOrders", x => x.id);
                    table.ForeignKey(
                        name: "FK_SuppliesOrders_Suppliers_supplier",
                        column: x => x.supplier,
                        principalTable: "Suppliers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order = table.Column<int>(type: "int", nullable: true),
                    product = table.Column<int>(type: "int", nullable: false),
                    supplies = table.Column<int>(type: "int", nullable: true),
                    unityPrice = table.Column<float>(type: "real", nullable: false),
                    quantity = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_ClientOrders_order",
                        column: x => x.order,
                        principalTable: "ClientOrders",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_product",
                        column: x => x.product,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_SuppliesOrders_supplies",
                        column: x => x.supplies,
                        principalTable: "SuppliesOrders",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_order",
                table: "OrderDetails",
                column: "order");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_product",
                table: "OrderDetails",
                column: "product");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_supplies",
                table: "OrderDetails",
                column: "supplies");

            migrationBuilder.CreateIndex(
                name: "IX_Products_type",
                table: "Products",
                column: "type");

            migrationBuilder.CreateIndex(
                name: "IX_SuppliesOrders_supplier",
                table: "SuppliesOrders",
                column: "supplier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ClientOrders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SuppliesOrders");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
