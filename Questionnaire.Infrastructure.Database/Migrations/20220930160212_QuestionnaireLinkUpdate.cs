using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Questionnaire.Infrastructure.Database.Migrations
{
    public partial class QuestionnaireLinkUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "QuestionnaireLink",
                newName: "Token");

            migrationBuilder.AddColumn<string>(
                name: "BaseAddress",
                table: "QuestionnaireLink",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PageAddress",
                table: "QuestionnaireLink",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionnaireId",
                table: "QuestionnaireLink",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseAddress",
                table: "QuestionnaireLink");

            migrationBuilder.DropColumn(
                name: "PageAddress",
                table: "QuestionnaireLink");

            migrationBuilder.DropColumn(
                name: "QuestionnaireId",
                table: "QuestionnaireLink");

            migrationBuilder.RenameColumn(
                name: "Token",
                table: "QuestionnaireLink",
                newName: "Url");
        }
    }
}
