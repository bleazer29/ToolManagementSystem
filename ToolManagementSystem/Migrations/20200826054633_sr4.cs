using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolManagementSystem.Client.Migrations
{
    public partial class sr4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolesPage_Page_PagesId",
                table: "RolesPage");

            migrationBuilder.DropForeignKey(
                name: "FK_RolesPage_Role_RoleId",
                table: "RolesPage");

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2020, 8, 26, 8, 46, 15, 976, DateTimeKind.Local).AddTicks(3629));

            migrationBuilder.AddForeignKey(
                name: "FK_RolesPage_Page_PagesId",
                table: "RolesPage",
                column: "PagesId",
                principalTable: "Page",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RolesPage_Role_RoleId",
                table: "RolesPage",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolesPage_Page_PagesId",
                table: "RolesPage");

            migrationBuilder.DropForeignKey(
                name: "FK_RolesPage_Role_RoleId",
                table: "RolesPage");

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2020, 8, 25, 22, 12, 2, 606, DateTimeKind.Local).AddTicks(7003));

            migrationBuilder.AddForeignKey(
                name: "FK_RolesPage_Page_PagesId",
                table: "RolesPage",
                column: "PagesId",
                principalTable: "Page",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolesPage_Role_RoleId",
                table: "RolesPage",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
