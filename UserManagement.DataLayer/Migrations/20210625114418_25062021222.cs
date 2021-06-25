using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.DataLayer.Migrations
{
    public partial class _25062021222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "Users");
        }
    }
}
