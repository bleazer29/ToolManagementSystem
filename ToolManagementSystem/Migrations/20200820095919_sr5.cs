using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolManagementSystem.Client.Migrations
{
    public partial class sr5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_UsersId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Employees_UsersId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "Employees",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Employees",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Employees",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Employees",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    PageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamePage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.PageId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolesId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRoles",
                columns: table => new
                {
                    EmployeeRolesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeesIdId = table.Column<int>(nullable: true),
                    RolesId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRoles", x => x.EmployeeRolesId);
                    table.ForeignKey(
                        name: "FK_EmployeeRoles_Employees_EmployeesIdId",
                        column: x => x.EmployeesIdId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeRoles_Roles_RolesId1",
                        column: x => x.RolesId1,
                        principalTable: "Roles",
                        principalColumn: "RolesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolesPages",
                columns: table => new
                {
                    RolesPagesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolesId1 = table.Column<int>(nullable: true),
                    PagesIdPageId = table.Column<int>(nullable: true),
                    IsVisible = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesPages", x => x.RolesPagesId);
                    table.ForeignKey(
                        name: "FK_RolesPages_Pages_PagesIdPageId",
                        column: x => x.PagesIdPageId,
                        principalTable: "Pages",
                        principalColumn: "PageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolesPages_Roles_RolesId1",
                        column: x => x.RolesId1,
                        principalTable: "Roles",
                        principalColumn: "RolesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoles_EmployeesIdId",
                table: "EmployeeRoles",
                column: "EmployeesIdId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoles_RolesId1",
                table: "EmployeeRoles",
                column: "RolesId1");

            migrationBuilder.CreateIndex(
                name: "IX_RolesPages_PagesIdPageId",
                table: "RolesPages",
                column: "PagesIdPageId");

            migrationBuilder.CreateIndex(
                name: "IX_RolesPages_RolesId1",
                table: "RolesPages",
                column: "RolesId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeRoles");

            migrationBuilder.DropTable(
                name: "RolesPages");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Question",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UsersId",
                table: "Employees",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_UsersId",
                table: "Employees",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
