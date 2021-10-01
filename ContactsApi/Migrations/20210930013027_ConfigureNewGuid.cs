using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ContactsApi.Migrations
{
    public partial class ConfigureNewGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Contacts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Company", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { new Guid("39f51b4a-f7c6-487a-b6a3-cec178eb7c22"), "DevWorking", "nalvarez23@live.com.ar", "Nahuel", "Alvarez", "+543794637353" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Company", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { new Guid("f5331dd7-41e4-4df8-b3a3-7909022b16f6"), "Development", "test@gmail.com", "Test", "Test", "+111111111111" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("39f51b4a-f7c6-487a-b6a3-cec178eb7c22"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("f5331dd7-41e4-4df8-b3a3-7909022b16f6"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Contacts",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");
        }
    }
}
