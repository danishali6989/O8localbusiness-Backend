using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.DataLayer.Migrations
{
    public partial class FormFieldChanges3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "FormField",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EnableOther",
                table: "FormField",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HelpText",
                table: "FormField",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Inline",
                table: "FormField",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Maxlength",
                table: "FormField",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Placeholder",
                table: "FormField",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Required",
                table: "FormField",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Rows",
                table: "FormField",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Toggle",
                table: "FormField",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "FormField");

            migrationBuilder.DropColumn(
                name: "EnableOther",
                table: "FormField");

            migrationBuilder.DropColumn(
                name: "HelpText",
                table: "FormField");

            migrationBuilder.DropColumn(
                name: "Inline",
                table: "FormField");

            migrationBuilder.DropColumn(
                name: "Maxlength",
                table: "FormField");

            migrationBuilder.DropColumn(
                name: "Placeholder",
                table: "FormField");

            migrationBuilder.DropColumn(
                name: "Required",
                table: "FormField");

            migrationBuilder.DropColumn(
                name: "Rows",
                table: "FormField");

            migrationBuilder.DropColumn(
                name: "Toggle",
                table: "FormField");
        }
    }
}
