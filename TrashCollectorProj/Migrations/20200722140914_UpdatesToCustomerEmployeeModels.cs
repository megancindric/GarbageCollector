using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProj.Migrations
{
    public partial class UpdatesToCustomerEmployeeModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af8d7293-4e23-4fd4-9e5c-4af63680ffef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f00f9611-497f-4bf6-82b2-c81710f300b2");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Employees",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Customers",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d083e08-63b7-486b-836c-69f624bdc0f8", "695e4f56-142e-4922-b2f6-467dfaaa6b7c", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "202eae13-4dc2-425e-af83-44ea7303934e", "f4981e4f-8915-4602-9ab3-ff83eb2ba996", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d083e08-63b7-486b-836c-69f624bdc0f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "202eae13-4dc2-425e-af83-44ea7303934e");

            migrationBuilder.AlterColumn<int>(
                name: "ZipCode",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<int>(
                name: "ZipCode",
                table: "Customers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 5);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "af8d7293-4e23-4fd4-9e5c-4af63680ffef", "a164e7f8-d1ab-492a-832a-2ef8b9817caf", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f00f9611-497f-4bf6-82b2-c81710f300b2", "17991588-85b2-406c-be94-b8ef19a03412", "Customer", "CUSTOMER" });
        }
    }
}
