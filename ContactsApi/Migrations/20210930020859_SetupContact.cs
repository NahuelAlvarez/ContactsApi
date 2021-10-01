using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ContactsApi.Migrations
{
    public partial class SetupContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("39f51b4a-f7c6-487a-b6a3-cec178eb7c22"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("f5331dd7-41e4-4df8-b3a3-7909022b16f6"));

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Company", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { new Guid("31b9ba25-d213-44b5-a0ea-1dc7d9ca6300"), "DevWorking", "nalvarez23@live.com.ar", "Nahuel", "Alvarez", "+543794637353" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Company", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { new Guid("fb832f2f-d6a3-4fae-a190-7a41879d0a0e"), "Development", "test@gmail.com", "Test", "Test", "+111111111111" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Company", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { new Guid("f4f4f178-7ba2-450a-86f5-3e902ae3bc93"), "Development2", "anothertest@gmail.com", "Test2", "Test2", "+12211111111111" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("31b9ba25-d213-44b5-a0ea-1dc7d9ca6300"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("f4f4f178-7ba2-450a-86f5-3e902ae3bc93"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("fb832f2f-d6a3-4fae-a190-7a41879d0a0e"));

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Company", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { new Guid("39f51b4a-f7c6-487a-b6a3-cec178eb7c22"), "DevWorking", "nalvarez23@live.com.ar", "Nahuel", "Alvarez", "+543794637353" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Company", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { new Guid("f5331dd7-41e4-4df8-b3a3-7909022b16f6"), "Development", "test@gmail.com", "Test", "Test", "+111111111111" });
        }
    }
}
