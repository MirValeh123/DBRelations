using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Explicit_Loading.Migrations
{
    /// <inheritdoc />
    public partial class initial_mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 4, 23, 15, 56, 39, 604, DateTimeKind.Local).AddTicks(2221));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 4, 23, 15, 56, 39, 604, DateTimeKind.Local).AddTicks(2230));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 4, 23, 15, 56, 39, 604, DateTimeKind.Local).AddTicks(2231));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2024, 4, 23, 15, 56, 39, 604, DateTimeKind.Local).AddTicks(2232));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2024, 4, 23, 15, 56, 39, 604, DateTimeKind.Local).AddTicks(2232));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "OrderDate",
                value: new DateTime(2024, 4, 23, 15, 56, 39, 604, DateTimeKind.Local).AddTicks(2233));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7,
                column: "OrderDate",
                value: new DateTime(2024, 4, 23, 15, 56, 39, 604, DateTimeKind.Local).AddTicks(2234));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 8,
                column: "OrderDate",
                value: new DateTime(2024, 4, 23, 15, 56, 39, 604, DateTimeKind.Local).AddTicks(2235));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 9,
                column: "OrderDate",
                value: new DateTime(2024, 4, 23, 15, 56, 39, 604, DateTimeKind.Local).AddTicks(2236));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderDate",
                value: new DateTime(2024, 4, 23, 15, 56, 39, 604, DateTimeKind.Local).AddTicks(2236));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11,
                column: "OrderDate",
                value: new DateTime(2024, 4, 23, 15, 56, 39, 604, DateTimeKind.Local).AddTicks(2237));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
