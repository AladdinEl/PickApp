using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KomOchHämta.Migrations
{
    /// <inheritdoc />
    public partial class AddedMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Message" },
                values: new object[] { new DateTime(2023, 8, 30, 10, 2, 25, 367, DateTimeKind.Local).AddTicks(1128), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Message" },
                values: new object[] { new DateTime(2023, 8, 30, 10, 2, 25, 367, DateTimeKind.Local).AddTicks(1187), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Message" },
                values: new object[] { new DateTime(2023, 8, 30, 10, 2, 25, 367, DateTimeKind.Local).AddTicks(1189), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 8, 30, 9, 55, 39, 264, DateTimeKind.Local).AddTicks(8804));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 8, 30, 9, 55, 39, 264, DateTimeKind.Local).AddTicks(8903));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 8, 30, 9, 55, 39, 264, DateTimeKind.Local).AddTicks(8906));
        }
    }
}
