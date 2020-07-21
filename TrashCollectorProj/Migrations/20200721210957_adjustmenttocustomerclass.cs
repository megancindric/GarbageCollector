using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProj.Migrations
{
    public partial class adjustmenttocustomerclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1319fffd-86d3-49b9-9c3d-9ffdd9c80dec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d5a7da7-f1b0-42f8-9cd8-166bd860763d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "60546f49-9438-4b74-8cd3-ccc4e24df535", "12776c32-131a-4e0b-a59a-c790c4830833", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bce9e720-0a1c-4642-bc0e-499948d858d4", "0754951b-3629-4c92-999e-9f723459ef5a", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60546f49-9438-4b74-8cd3-ccc4e24df535");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bce9e720-0a1c-4642-bc0e-499948d858d4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7d5a7da7-f1b0-42f8-9cd8-166bd860763d", "3177b830-a845-4e95-9e6b-afbe4b5bbee2", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1319fffd-86d3-49b9-9c3d-9ffdd9c80dec", "c6b1ea6f-dce3-4693-bbcc-5232371787f9", "Customer", "CUSTOMER" });
        }
    }
}
