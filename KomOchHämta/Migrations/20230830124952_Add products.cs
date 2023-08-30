using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KomOchHämta.Migrations
{
    /// <inheritdoc />
    public partial class Addproducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Created", "Description", "Image", "Location", "Message", "ProductName", "Reserved", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 30, 14, 49, 52, 730, DateTimeKind.Local).AddTicks(4361), "Dyr", "Bild1", null, null, "Lampa", false, null },
                    { 2, new DateTime(2023, 8, 30, 14, 49, 52, 730, DateTimeKind.Local).AddTicks(4413), "Billig", "Bild2", null, null, "Soffa", false, null },
                    { 3, new DateTime(2023, 8, 30, 14, 49, 52, 730, DateTimeKind.Local).AddTicks(4415), "Rea", "Bild3", null, null, "Stol", false, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
