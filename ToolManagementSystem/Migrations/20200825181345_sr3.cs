using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolManagementSystem.Client.Migrations
{
    public partial class sr3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "EmployeeRole",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2020, 8, 25, 21, 13, 41, 233, DateTimeKind.Local).AddTicks(226));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "EmployeeRole");

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2020, 8, 25, 18, 32, 35, 929, DateTimeKind.Local).AddTicks(6761));
        }
    }
}
