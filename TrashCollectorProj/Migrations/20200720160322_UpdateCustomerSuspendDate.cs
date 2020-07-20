using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProj.Migrations
{
    public partial class UpdateCustomerSuspendDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e4d552e-fd0c-4b0b-8e7e-2309806c831a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6ffbcfe-a332-4147-ac34-f0b8cfabcaeb");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExtraPickupDate",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SuspendedEndDate",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SuspendedStartDate",
                table: "Customer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8ead62db-9337-4b2b-8af1-a1c4fd118eb9", "b5a70d1c-8690-4a5e-91ad-db7a9195e3f2", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d99764db-a6f6-47a4-8e36-c1d8f79e851c", "ddebf4b0-be0b-4d38-841c-62539329e8d8", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ead62db-9337-4b2b-8af1-a1c4fd118eb9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d99764db-a6f6-47a4-8e36-c1d8f79e851c");

            migrationBuilder.DropColumn(
                name: "ExtraPickupDate",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "SuspendedEndDate",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "SuspendedStartDate",
                table: "Customer");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3e4d552e-fd0c-4b0b-8e7e-2309806c831a", "a277818a-41c7-442c-a803-360b52242156", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f6ffbcfe-a332-4147-ac34-f0b8cfabcaeb", "484d0734-eeaa-41fd-a1cb-0926e1664205", "Customer", "CUSTOMER" });
        }
    }
}
