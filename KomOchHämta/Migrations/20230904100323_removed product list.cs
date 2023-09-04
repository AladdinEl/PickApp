using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KomOchHämta.Migrations
{
    /// <inheritdoc />
    public partial class removedproductlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Created", "Description", "Image", "Location", "Message", "ProductName", "Reserved", "ReservedBy", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 31, 16, 35, 26, 25, DateTimeKind.Local).AddTicks(5868), "Dyr", null, null, null, "Lampa", false, null, null },
                    { 2, new DateTime(2023, 8, 31, 16, 35, 26, 25, DateTimeKind.Local).AddTicks(5974), "Billig", null, null, null, "Soffa", false, null, null },
                    { 3, new DateTime(2023, 8, 31, 16, 35, 26, 25, DateTimeKind.Local).AddTicks(5982), "Rea", null, null, null, "Stol", false, null, null }
                });
        }
    }
}
