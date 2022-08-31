using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Questionnaire.Infrastructure.Database.Migrations
{
    public partial class AnswerStructureId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Structure_QuestionnaireId",
                table: "Answer");

            migrationBuilder.RenameColumn(
                name: "QuestionnaireId",
                table: "Answer",
                newName: "StructureId");

            migrationBuilder.RenameIndex(
                name: "IX_Answer_QuestionnaireId",
                table: "Answer",
                newName: "IX_Answer_StructureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Structure_StructureId",
                table: "Answer",
                column: "StructureId",
                principalTable: "Structure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Structure_StructureId",
                table: "Answer");

            migrationBuilder.RenameColumn(
                name: "StructureId",
                table: "Answer",
                newName: "QuestionnaireId");

            migrationBuilder.RenameIndex(
                name: "IX_Answer_StructureId",
                table: "Answer",
                newName: "IX_Answer_QuestionnaireId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Structure_QuestionnaireId",
                table: "Answer",
                column: "QuestionnaireId",
                principalTable: "Structure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
