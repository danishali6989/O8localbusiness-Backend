using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.DataLayer.Migrations
{
    public partial class businessAlias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BusinessAlias",
                table: "Form",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BusinessCategoryId",
                table: "BusinessSubCategory",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessAlias",
                table: "Form");

            migrationBuilder.DropColumn(
                name: "BusinessCategoryId",
                table: "BusinessSubCategory");
        }
    }
}
