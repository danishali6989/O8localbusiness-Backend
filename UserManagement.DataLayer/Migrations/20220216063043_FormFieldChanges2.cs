using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.DataLayer.Migrations
{
    public partial class FormFieldChanges2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Access",
                table: "FormField",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "FormField",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "FormField",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FormBuilderTypeId",
                table: "FormField",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FormField",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "FormField",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Style",
                table: "FormField",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "FormField",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "FormField",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "FormField",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Value",
                table: "FormField",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FormField_FormBuilderTypeId",
                table: "FormField",
                column: "FormBuilderTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormField_FormBuilderType_FormBuilderTypeId",
                table: "FormField",
                column: "FormBuilderTypeId",
                principalTable: "FormBuilderType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormField_FormBuilderType_FormBuilderTypeId",
                table: "FormField");

            migrationBuilder.DropIndex(
                name: "IX_FormField_FormBuilderTypeId",
                table: "FormField");

            migrationBuilder.DropColumn(
                name: "Access",
                table: "FormField");

            migrationBuilder.DropColumn(
                name: "Class",
                table: "FormField");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "FormField");

            migrationBuilder.DropColumn(
                name: "FormBuilderTypeId",
                table: "FormField");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "FormField");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "FormField");

            migrationBuilder.DropColumn(
                name: "Style",
                table: "FormField");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "FormField");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "FormField");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "FormField");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "FormField");
        }
    }
}
