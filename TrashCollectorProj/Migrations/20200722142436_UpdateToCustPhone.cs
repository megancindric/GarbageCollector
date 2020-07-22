using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProj.Migrations
{
    public partial class UpdateToCustPhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d083e08-63b7-486b-836c-69f624bdc0f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "202eae13-4dc2-425e-af83-44ea7303934e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d1dd560d-e353-4285-bda3-d71a0d2c8d1b", "4da7461a-1205-435b-9ea9-bd902f0dd0bf", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "17d76124-2271-4027-9bd5-d8ac6d708f15", "b2abb19a-270a-4475-907d-d2c54a1b355c", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17d76124-2271-4027-9bd5-d8ac6d708f15");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1dd560d-e353-4285-bda3-d71a0d2c8d1b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d083e08-63b7-486b-836c-69f624bdc0f8", "695e4f56-142e-4922-b2f6-467dfaaa6b7c", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "202eae13-4dc2-425e-af83-44ea7303934e", "f4981e4f-8915-4602-9ab3-ff83eb2ba996", "Customer", "CUSTOMER" });
        }
    }
}
