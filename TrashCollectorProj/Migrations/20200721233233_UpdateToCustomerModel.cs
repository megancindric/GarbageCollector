using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProj.Migrations
{
    public partial class UpdateToCustomerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60546f49-9438-4b74-8cd3-ccc4e24df535");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bce9e720-0a1c-4642-bc0e-499948d858d4");

            migrationBuilder.DropColumn(
                name: "HasExtraPickup",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsSuspended",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0913f4b8-554c-439c-8393-164df8734a75", "3a6f8a5b-db69-441c-8981-10728f1702ff", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "35aa45d7-32bf-488b-be02-c3fd5170411c", "1c2a2981-8b96-4727-8eda-4378ed0e7dc0", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0913f4b8-554c-439c-8393-164df8734a75");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35aa45d7-32bf-488b-be02-c3fd5170411c");

            migrationBuilder.AddColumn<bool>(
                name: "HasExtraPickup",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSuspended",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "60546f49-9438-4b74-8cd3-ccc4e24df535", "12776c32-131a-4e0b-a59a-c790c4830833", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bce9e720-0a1c-4642-bc0e-499948d858d4", "0754951b-3629-4c92-999e-9f723459ef5a", "Customer", "CUSTOMER" });
        }
    }
}
