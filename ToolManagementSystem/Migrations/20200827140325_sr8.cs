using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolManagementSystem.Client.Migrations
{
    public partial class sr8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVisible",
                table: "RolesPage");

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2020, 8, 27, 17, 3, 21, 313, DateTimeKind.Local).AddTicks(9425));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVisible",
                table: "RolesPage",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2020, 8, 26, 15, 18, 22, 310, DateTimeKind.Local).AddTicks(5435));

            migrationBuilder.UpdateData(
                table: "RolesPage",
                keyColumns: new[] { "RoleId", "PagesId" },
                keyValues: new object[] { 1, 1 },
                column: "IsVisible",
                value: true);

            migrationBuilder.UpdateData(
                table: "RolesPage",
                keyColumns: new[] { "RoleId", "PagesId" },
                keyValues: new object[] { 1, 2 },
                column: "IsVisible",
                value: true);

            migrationBuilder.UpdateData(
                table: "RolesPage",
                keyColumns: new[] { "RoleId", "PagesId" },
                keyValues: new object[] { 1, 3 },
                column: "IsVisible",
                value: true);
        }
    }
}
