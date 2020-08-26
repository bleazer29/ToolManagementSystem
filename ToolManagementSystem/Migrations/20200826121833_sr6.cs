using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolManagementSystem.Client.Migrations
{
    public partial class sr6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2020, 8, 26, 15, 18, 22, 310, DateTimeKind.Local).AddTicks(5435));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2020, 8, 26, 11, 12, 39, 32, DateTimeKind.Local).AddTicks(6084));
        }
    }
}
