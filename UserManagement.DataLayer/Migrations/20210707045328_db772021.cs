using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.DataLayer.Migrations
{
    public partial class db772021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ScreenUrl",
                table: "ScreenDetail",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScreenUrl",
                table: "ScreenDetail");
        }
    }
}
