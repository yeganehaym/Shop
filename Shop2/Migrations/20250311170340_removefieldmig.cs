using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop2.Migrations
{
    /// <inheritdoc />
    public partial class removefieldmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "Invoices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "InvoiceItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "Carts",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "Carts");
        }
    }
}
