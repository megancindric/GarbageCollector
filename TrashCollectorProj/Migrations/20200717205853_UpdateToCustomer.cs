using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProj.Migrations
{
    public partial class UpdateToCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70f043a8-6d14-441a-805d-3d9addc0a7d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "feb03615-93d0-40d0-9203-19c7db0f40b9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bb7ae760-703f-4299-84df-bdf7fdd35872", "c2d9fd5f-c042-4389-911c-d6d24d2ac0e4", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "96e02cc7-8ad0-4805-8b48-1a1dd08a507f", "65c32228-a88e-423d-8127-0c4156ffa147", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96e02cc7-8ad0-4805-8b48-1a1dd08a507f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb7ae760-703f-4299-84df-bdf7fdd35872");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "70f043a8-6d14-441a-805d-3d9addc0a7d9", "10fba11c-6867-44fe-8aa2-aa17c2b0e24e", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "feb03615-93d0-40d0-9203-19c7db0f40b9", "00a3728f-6549-4c16-b251-ad03eb4dfa60", "Customer", "CUSTOMER" });
        }
    }
}
