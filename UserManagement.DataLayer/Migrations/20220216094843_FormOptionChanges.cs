using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.DataLayer.Migrations
{
    public partial class FormOptionChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "FormOption",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "FormOption",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "FormOption",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "FormOption",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "FormOption",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "FormOption",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "FormOption");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "FormOption");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "FormOption");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "FormOption");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "FormOption");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "FormOption");
        }
    }
}
