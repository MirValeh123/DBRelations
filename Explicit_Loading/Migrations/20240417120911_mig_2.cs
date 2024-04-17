using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Explicit_Loading.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 4, 17, 16, 9, 11, 629, DateTimeKind.Local).AddTicks(4123));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 4, 17, 16, 9, 11, 629, DateTimeKind.Local).AddTicks(4134));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 4, 17, 16, 9, 11, 629, DateTimeKind.Local).AddTicks(4135));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2024, 4, 17, 16, 9, 11, 629, DateTimeKind.Local).AddTicks(4136));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2024, 4, 17, 16, 9, 11, 629, DateTimeKind.Local).AddTicks(4137));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "OrderDate",
                value: new DateTime(2024, 4, 17, 16, 9, 11, 629, DateTimeKind.Local).AddTicks(4138));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7,
                column: "OrderDate",
                value: new DateTime(2024, 4, 17, 16, 9, 11, 629, DateTimeKind.Local).AddTicks(4138));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 8,
                column: "OrderDate",
                value: new DateTime(2024, 4, 17, 16, 9, 11, 629, DateTimeKind.Local).AddTicks(4139));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 9,
                column: "OrderDate",
                value: new DateTime(2024, 4, 17, 16, 9, 11, 629, DateTimeKind.Local).AddTicks(4140));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderDate",
                value: new DateTime(2024, 4, 17, 16, 9, 11, 629, DateTimeKind.Local).AddTicks(4141));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11,
                column: "OrderDate",
                value: new DateTime(2024, 4, 17, 16, 9, 11, 629, DateTimeKind.Local).AddTicks(4142));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 4, 17, 15, 51, 47, 303, DateTimeKind.Local).AddTicks(4073));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 4, 17, 15, 51, 47, 303, DateTimeKind.Local).AddTicks(4083));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 4, 17, 15, 51, 47, 303, DateTimeKind.Local).AddTicks(4084));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2024, 4, 17, 15, 51, 47, 303, DateTimeKind.Local).AddTicks(4085));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2024, 4, 17, 15, 51, 47, 303, DateTimeKind.Local).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "OrderDate",
                value: new DateTime(2024, 4, 17, 15, 51, 47, 303, DateTimeKind.Local).AddTicks(4087));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7,
                column: "OrderDate",
                value: new DateTime(2024, 4, 17, 15, 51, 47, 303, DateTimeKind.Local).AddTicks(4088));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 8,
                column: "OrderDate",
                value: new DateTime(2024, 4, 17, 15, 51, 47, 303, DateTimeKind.Local).AddTicks(4088));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 9,
                column: "OrderDate",
                value: new DateTime(2024, 4, 17, 15, 51, 47, 303, DateTimeKind.Local).AddTicks(4089));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderDate",
                value: new DateTime(2024, 4, 17, 15, 51, 47, 303, DateTimeKind.Local).AddTicks(4090));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11,
                column: "OrderDate",
                value: new DateTime(2024, 4, 17, 15, 51, 47, 303, DateTimeKind.Local).AddTicks(4091));
        }
    }
}
