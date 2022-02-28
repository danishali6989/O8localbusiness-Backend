using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.DataLayer.Migrations
{
    public partial class formfieldremovefk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormField_FormBuilderType_FormBuilderTypeId",
                table: "FormField");

            migrationBuilder.DropIndex(
                name: "IX_FormField_FormBuilderTypeId",
                table: "FormField");

            migrationBuilder.AlterColumn<int>(
                name: "FormBuilderTypeId",
                table: "FormField",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FormBuilderTypeId",
                table: "FormField",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
    }
}
