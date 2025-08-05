using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Destek.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mgr_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_WarehouseCategories_WarehouseCategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseTransactions_Products_ProductId",
                table: "WarehouseTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseTransactions_Warehouses_WarehouseId",
                table: "WarehouseTransactions");

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("378db3bd-a470-4df6-84ee-6e8f9470ba72"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("43e92347-7ec6-4b5e-815b-62b5b870a681"));

           

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_WarehouseCategories_WarehouseCategoryId",
                table: "Products",
                column: "WarehouseCategoryId",
                principalTable: "WarehouseCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseTransactions_Products_ProductId",
                table: "WarehouseTransactions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseTransactions_Warehouses_WarehouseId",
                table: "WarehouseTransactions",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_WarehouseCategories_WarehouseCategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseTransactions_Products_ProductId",
                table: "WarehouseTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseTransactions_Warehouses_WarehouseId",
                table: "WarehouseTransactions");

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("59d7a5b7-b54d-4f3a-8223-88d154f294f3"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("ead2b783-b192-48e0-b88d-6497ece1d847"));

           

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_WarehouseCategories_WarehouseCategoryId",
                table: "Products",
                column: "WarehouseCategoryId",
                principalTable: "WarehouseCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseTransactions_Products_ProductId",
                table: "WarehouseTransactions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseTransactions_Warehouses_WarehouseId",
                table: "WarehouseTransactions",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
