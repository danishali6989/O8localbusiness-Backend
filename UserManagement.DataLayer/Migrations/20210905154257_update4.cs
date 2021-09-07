using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.DataLayer.Migrations
{
    public partial class update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_Pid",
                table: "RolePermission",
                column: "Pid");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_Roleid",
                table: "RolePermission",
                column: "Roleid");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermission_Permi_Pid",
                table: "RolePermission",
                column: "Pid",
                principalTable: "Permi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermission_UserRoles_Roleid",
                table: "RolePermission",
                column: "Roleid",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermission_Permi_Pid",
                table: "RolePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermission_UserRoles_Roleid",
                table: "RolePermission");

            migrationBuilder.DropIndex(
                name: "IX_RolePermission_Pid",
                table: "RolePermission");

            migrationBuilder.DropIndex(
                name: "IX_RolePermission_Roleid",
                table: "RolePermission");
        }
    }
}
