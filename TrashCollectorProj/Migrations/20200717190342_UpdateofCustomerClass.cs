using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProj.Migrations
{
    public partial class UpdateofCustomerClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5008bb33-44a9-448b-a49a-49981b7363f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d3d9005-dded-4e98-9521-d7ca11ca7c40");

            migrationBuilder.AddColumn<bool>(
                name: "IsSuspended",
                table: "Customer",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "70f043a8-6d14-441a-805d-3d9addc0a7d9", "10fba11c-6867-44fe-8aa2-aa17c2b0e24e", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "feb03615-93d0-40d0-9203-19c7db0f40b9", "00a3728f-6549-4c16-b251-ad03eb4dfa60", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70f043a8-6d14-441a-805d-3d9addc0a7d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "feb03615-93d0-40d0-9203-19c7db0f40b9");

            migrationBuilder.DropColumn(
                name: "IsSuspended",
                table: "Customer");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5008bb33-44a9-448b-a49a-49981b7363f9", "e8c3fb2f-9c36-4e5a-b78c-e8241f87373a", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9d3d9005-dded-4e98-9521-d7ca11ca7c40", "083ebac1-ba20-469b-a2d4-a6ece3898cb8", "Customer", "CUSTOMER" });
        }
    }
}
