using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KomOchHämta.Migrations
{
    /// <inheritdoc />
    public partial class Addedlocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Location" },
                values: new object[] { new DateTime(2023, 8, 30, 9, 55, 39, 264, DateTimeKind.Local).AddTicks(8804), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Location" },
                values: new object[] { new DateTime(2023, 8, 30, 9, 55, 39, 264, DateTimeKind.Local).AddTicks(8903), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Location" },
                values: new object[] { new DateTime(2023, 8, 30, 9, 55, 39, 264, DateTimeKind.Local).AddTicks(8906), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 8, 29, 15, 42, 10, 880, DateTimeKind.Local).AddTicks(1572));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 8, 29, 15, 42, 10, 880, DateTimeKind.Local).AddTicks(1633));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 8, 29, 15, 42, 10, 880, DateTimeKind.Local).AddTicks(1637));
        }
    }
}
