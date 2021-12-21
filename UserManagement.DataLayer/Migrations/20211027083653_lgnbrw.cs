using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.DataLayer.Migrations
{
    public partial class lgnbrw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BrowserAgent",
                table: "LoginModule",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ip_Address",
                table: "LoginModule",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrowserAgent",
                table: "LoginModule");

            migrationBuilder.DropColumn(
                name: "Ip_Address",
                table: "LoginModule");
        }
    }
}
