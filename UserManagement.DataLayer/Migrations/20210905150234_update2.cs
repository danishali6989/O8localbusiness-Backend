using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.DataLayer.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermission_Permi_PermiId",
                table: "RolePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermission_UserRoles_Roleid",
                table: "RolePermission");

            migrationBuilder.DropIndex(
                name: "IX_RolePermission_PermiId",
                table: "RolePermission");

            migrationBuilder.DropIndex(
                name: "IX_RolePermission_Roleid",
                table: "RolePermission");

            migrationBuilder.DropColumn(
                name: "PermiId",
                table: "RolePermission");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PermiId",
                table: "RolePermission",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_PermiId",
                table: "RolePermission",
                column: "PermiId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_Roleid",
                table: "RolePermission",
                column: "Roleid");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermission_Permi_PermiId",
                table: "RolePermission",
                column: "PermiId",
                principalTable: "Permi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermission_UserRoles_Roleid",
                table: "RolePermission",
                column: "Roleid",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
