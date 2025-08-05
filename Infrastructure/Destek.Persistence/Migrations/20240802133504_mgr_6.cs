using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Destek.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mgr_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TicketId",
                table: "WarehouseTransactions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseTransactions_TicketId",
                table: "WarehouseTransactions",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseTransactions_Tickets_TicketId",
                table: "WarehouseTransactions",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseTransactions_Tickets_TicketId",
                table: "WarehouseTransactions");

            migrationBuilder.DropIndex(
                name: "IX_WarehouseTransactions_TicketId",
                table: "WarehouseTransactions");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "WarehouseTransactions");
        }
    }
}
