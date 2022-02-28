using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.DataLayer.Migrations
{
    public partial class removeClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Class",
                table: "FormField");

            migrationBuilder.AddColumn<bool>(
                name: "requireValidOption",
                table: "FormField",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "requireValidOption",
                table: "FormField");

            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "FormField",
                nullable: true);
        }
    }
}
