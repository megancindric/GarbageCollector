using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProj.Migrations
{
    public partial class UpdateOfviewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0913f4b8-554c-439c-8393-164df8734a75");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35aa45d7-32bf-488b-be02-c3fd5170411c");

            migrationBuilder.AlterColumn<string>(
                name: "PickupDay",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "423b4504-28ed-416f-b4b0-37c02ec28945", "dc5c86e6-d353-4b7a-8e07-d51e40d9620e", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "09beddd4-77fc-416c-92a5-e60173a2c9c9", "8d48a70e-cd3a-4840-b7bc-e37cb5d7ed8f", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09beddd4-77fc-416c-92a5-e60173a2c9c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "423b4504-28ed-416f-b4b0-37c02ec28945");

            migrationBuilder.AlterColumn<int>(
                name: "PickupDay",
                table: "Customers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0913f4b8-554c-439c-8393-164df8734a75", "3a6f8a5b-db69-441c-8981-10728f1702ff", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "35aa45d7-32bf-488b-be02-c3fd5170411c", "1c2a2981-8b96-4727-8eda-4378ed0e7dc0", "Customer", "CUSTOMER" });
        }
    }
}
