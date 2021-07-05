using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.DataLayer.Migrations
{
    public partial class db05072021222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "UserScreenAccess",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "UserScreenAccess");
        }
    }
}
