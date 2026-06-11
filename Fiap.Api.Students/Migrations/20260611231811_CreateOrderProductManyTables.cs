using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Api.Students.Migrations
{
    /// <inheritdoc />
    public partial class CreateOrderProductManyTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "API_STORE",
                columns: table => new
                {
                    StoreId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_API_STORE", x => x.StoreId);
                });

            migrationBuilder.CreateTable(
                name: "API_SUPPLIER",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_API_SUPPLIER", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "API_ORDER",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    OrderDate = table.Column<DateTime>(type: "date", nullable: false),
                    ClientId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    StoreId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_API_ORDER", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_API_ORDER_API_CLIENT_ClientId",
                        column: x => x.ClientId,
                        principalTable: "API_CLIENT",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_API_ORDER_API_STORE_StoreId",
                        column: x => x.StoreId,
                        principalTable: "API_STORE",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "API_PRODUCT",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SupplierId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_API_PRODUCT", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_API_PRODUCT_API_SUPPLIER_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "API_SUPPLIER",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ProductId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderProducts_API_ORDER_OrderId",
                        column: x => x.OrderId,
                        principalTable: "API_ORDER",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_API_PRODUCT_ProductId",
                        column: x => x.ProductId,
                        principalTable: "API_PRODUCT",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_API_ORDER_ClientId",
                table: "API_ORDER",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_API_ORDER_StoreId",
                table: "API_ORDER",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_API_PRODUCT_SupplierId",
                table: "API_PRODUCT",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "API_ORDER");

            migrationBuilder.DropTable(
                name: "API_PRODUCT");

            migrationBuilder.DropTable(
                name: "API_STORE");

            migrationBuilder.DropTable(
                name: "API_SUPPLIER");
        }
    }
}
