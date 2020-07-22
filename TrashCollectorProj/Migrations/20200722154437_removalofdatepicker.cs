using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProj.Migrations
{
    public partial class removalofdatepicker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47594072-2217-4752-b484-e835708f3a79");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92840292-5f85-434c-974d-7a88cfd8d05a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "734eae08-4d71-4bdf-8657-0f15b4164f02", "9821c8a5-3950-4730-9560-ac1b5b2d7131", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e4754f3d-643e-404b-ab1b-6f90951d09ec", "0e792310-d4f6-4bd6-9e00-488e0b4f61d8", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "734eae08-4d71-4bdf-8657-0f15b4164f02");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4754f3d-643e-404b-ab1b-6f90951d09ec");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "47594072-2217-4752-b484-e835708f3a79", "795d6054-4973-4f45-bf92-8dad66e125fa", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "92840292-5f85-434c-974d-7a88cfd8d05a", "b8206e89-c555-4066-b786-e2f0d913c671", "Customer", "CUSTOMER" });
        }
    }
}
