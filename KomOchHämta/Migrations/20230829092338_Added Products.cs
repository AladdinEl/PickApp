using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KomOchHämta.Migrations
{
    /// <inheritdoc />
    public partial class AddedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Created", "Description", "Image", "ProductName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 29, 11, 23, 37, 905, DateTimeKind.Local).AddTicks(9265), "Dyr", "Bild1", "Lampa" },
                    { 2, new DateTime(2023, 8, 29, 11, 23, 37, 905, DateTimeKind.Local).AddTicks(9365), "Billig", "Bild2", "Soffa" },
                    { 3, new DateTime(2023, 8, 29, 11, 23, 37, 905, DateTimeKind.Local).AddTicks(9368), "Rea", "Bild3", "Stol" }
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
