using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProj.Migrations
{
    public partial class UpdateofCustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96e02cc7-8ad0-4805-8b48-1a1dd08a507f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb7ae760-703f-4299-84df-bdf7fdd35872");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastPickupDate",
                table: "Customer",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "TrashFees",
                table: "Customer",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3e4d552e-fd0c-4b0b-8e7e-2309806c831a", "a277818a-41c7-442c-a803-360b52242156", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f6ffbcfe-a332-4147-ac34-f0b8cfabcaeb", "484d0734-eeaa-41fd-a1cb-0926e1664205", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e4d552e-fd0c-4b0b-8e7e-2309806c831a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6ffbcfe-a332-4147-ac34-f0b8cfabcaeb");

            migrationBuilder.DropColumn(
                name: "LastPickupDate",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "TrashFees",
                table: "Customer");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bb7ae760-703f-4299-84df-bdf7fdd35872", "c2d9fd5f-c042-4389-911c-d6d24d2ac0e4", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "96e02cc7-8ad0-4805-8b48-1a1dd08a507f", "65c32228-a88e-423d-8127-0c4156ffa147", "Customer", "CUSTOMER" });
        }
    }
}
