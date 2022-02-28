using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.DataLayer.Migrations
{
    public partial class UserNAmeDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Form",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Form",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Form");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Form");
        }
    }
}
