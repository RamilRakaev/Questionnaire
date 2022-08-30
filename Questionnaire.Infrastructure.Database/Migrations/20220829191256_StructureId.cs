using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Questionnaire.Infrastructure.Database.Migrations
{
    public partial class StructureId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_Structure_QuestionnaireId",
                table: "Property");

            migrationBuilder.RenameColumn(
                name: "QuestionnaireId",
                table: "Property",
                newName: "StructureId");

            migrationBuilder.RenameIndex(
                name: "IX_Property_QuestionnaireId",
                table: "Property",
                newName: "IX_Property_StructureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Structure_StructureId",
                table: "Property",
                column: "StructureId",
                principalTable: "Structure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_Structure_StructureId",
                table: "Property");

            migrationBuilder.RenameColumn(
                name: "StructureId",
                table: "Property",
                newName: "QuestionnaireId");

            migrationBuilder.RenameIndex(
                name: "IX_Property_StructureId",
                table: "Property",
                newName: "IX_Property_QuestionnaireId");

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Structure_QuestionnaireId",
                table: "Property",
                column: "QuestionnaireId",
                principalTable: "Structure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
