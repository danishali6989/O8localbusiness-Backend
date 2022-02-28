using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.DataLayer.Migrations
{
    public partial class changesinform : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Form",
                newName: "PostalCode");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Form",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BusinessName",
                table: "Form",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Form",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MobileNo",
                table: "Form",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Form");

            migrationBuilder.DropColumn(
                name: "BusinessName",
                table: "Form");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Form");

            migrationBuilder.DropColumn(
                name: "MobileNo",
                table: "Form");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Form",
                newName: "Title");
        }
    }
}
