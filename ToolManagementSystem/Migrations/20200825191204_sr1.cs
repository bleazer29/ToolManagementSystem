using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolManagementSystem.Client.Migrations
{
    public partial class sr1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2020, 8, 25, 22, 12, 2, 606, DateTimeKind.Local).AddTicks(7003));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2020, 8, 25, 21, 13, 41, 233, DateTimeKind.Local).AddTicks(226));
        }
    }
}
