using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KomOchHämta.Migrations
{
    /// <inheritdoc />
    public partial class AddedReservedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReservedBy",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "ReservedBy" },
                values: new object[] { new DateTime(2023, 8, 31, 10, 35, 57, 106, DateTimeKind.Local).AddTicks(5815), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "ReservedBy" },
                values: new object[] { new DateTime(2023, 8, 31, 10, 35, 57, 106, DateTimeKind.Local).AddTicks(5871), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "ReservedBy" },
                values: new object[] { new DateTime(2023, 8, 31, 10, 35, 57, 106, DateTimeKind.Local).AddTicks(5873), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservedBy",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 8, 30, 14, 49, 52, 730, DateTimeKind.Local).AddTicks(4361));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 8, 30, 14, 49, 52, 730, DateTimeKind.Local).AddTicks(4413));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 8, 30, 14, 49, 52, 730, DateTimeKind.Local).AddTicks(4415));
        }
    }
}
