using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KomOchHämta.Migrations
{
    /// <inheritdoc />
    public partial class Addedreserved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Reserved",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Reserved", "UserId" },
                values: new object[] { new DateTime(2023, 8, 29, 15, 42, 10, 880, DateTimeKind.Local).AddTicks(1572), false, 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Reserved", "UserId" },
                values: new object[] { new DateTime(2023, 8, 29, 15, 42, 10, 880, DateTimeKind.Local).AddTicks(1633), false, 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Reserved", "UserId" },
                values: new object[] { new DateTime(2023, 8, 29, 15, 42, 10, 880, DateTimeKind.Local).AddTicks(1637), false, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reserved",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 8, 29, 11, 33, 37, 78, DateTimeKind.Local).AddTicks(1511));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 8, 29, 11, 33, 37, 78, DateTimeKind.Local).AddTicks(1574));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 8, 29, 11, 33, 37, 78, DateTimeKind.Local).AddTicks(1576));
        }
    }
}
