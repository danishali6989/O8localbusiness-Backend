using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.DataLayer.Migrations
{
    public partial class db897979 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "UserScreenAccess");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "UserScreenAccess",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserScreenAccess_RoleId",
                table: "UserScreenAccess",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserScreenAccess_UserRoles_RoleId",
                table: "UserScreenAccess",
                column: "RoleId",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserScreenAccess_UserRoles_RoleId",
                table: "UserScreenAccess");

            migrationBuilder.DropIndex(
                name: "IX_UserScreenAccess_RoleId",
                table: "UserScreenAccess");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "UserScreenAccess");

            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                table: "UserScreenAccess",
                nullable: false,
                defaultValue: 0);
        }
    }
}
