using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.DataLayer.Migrations
{
    public partial class _2585542 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "App_id",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "App_id",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
