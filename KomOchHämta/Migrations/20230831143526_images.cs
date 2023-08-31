using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KomOchHämta.Migrations
{
    /// <inheritdoc />
    public partial class images : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Image" },
                values: new object[] { new DateTime(2023, 8, 31, 16, 35, 26, 25, DateTimeKind.Local).AddTicks(5868), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Image" },
                values: new object[] { new DateTime(2023, 8, 31, 16, 35, 26, 25, DateTimeKind.Local).AddTicks(5974), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Image" },
                values: new object[] { new DateTime(2023, 8, 31, 16, 35, 26, 25, DateTimeKind.Local).AddTicks(5982), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Image" },
                values: new object[] { new DateTime(2023, 8, 31, 10, 35, 57, 106, DateTimeKind.Local).AddTicks(5815), "Bild1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Image" },
                values: new object[] { new DateTime(2023, 8, 31, 10, 35, 57, 106, DateTimeKind.Local).AddTicks(5871), "Bild2" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Image" },
                values: new object[] { new DateTime(2023, 8, 31, 10, 35, 57, 106, DateTimeKind.Local).AddTicks(5873), "Bild3" });
        }
    }
}
