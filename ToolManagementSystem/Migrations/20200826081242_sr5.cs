using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolManagementSystem.Client.Migrations
{
    public partial class sr5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "EmployeeRole");

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2020, 8, 26, 11, 12, 39, 32, DateTimeKind.Local).AddTicks(6084));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "EmployeeRole",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2020, 8, 26, 8, 46, 15, 976, DateTimeKind.Local).AddTicks(3629));
        }
    }
}
