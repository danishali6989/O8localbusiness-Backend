using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.DataLayer.Migrations
{
    public partial class slsdlsdl123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermission_Permi_Pid",
                table: "RolePermission");

            migrationBuilder.DropIndex(
                name: "IX_RolePermission_Pid",
                table: "RolePermission");

            migrationBuilder.AddColumn<int>(
                name: "PermiId",
                table: "RolePermission",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_PermiId",
                table: "RolePermission",
                column: "PermiId");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermission_Permi_PermiId",
                table: "RolePermission",
                column: "PermiId",
                principalTable: "Permi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermission_Permi_PermiId",
                table: "RolePermission");

            migrationBuilder.DropIndex(
                name: "IX_RolePermission_PermiId",
                table: "RolePermission");

            migrationBuilder.DropColumn(
                name: "PermiId",
                table: "RolePermission");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_Pid",
                table: "RolePermission",
                column: "Pid");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermission_Permi_Pid",
                table: "RolePermission",
                column: "Pid",
                principalTable: "Permi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
