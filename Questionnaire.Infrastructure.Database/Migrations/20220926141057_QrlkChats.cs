using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Questionnaire.Infrastructure.Database.Migrations
{
    public partial class QrlkChats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_QrlkChat_QrlkChatId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_QrlkChatId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "QrlkChatId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "QrlkChat",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_QrlkChat_UserId",
                table: "QrlkChat",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_QrlkChat_AspNetUsers_UserId",
                table: "QrlkChat",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QrlkChat_AspNetUsers_UserId",
                table: "QrlkChat");

            migrationBuilder.DropIndex(
                name: "IX_QrlkChat_UserId",
                table: "QrlkChat");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "QrlkChat",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<int>(
                name: "QrlkChatId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_QrlkChatId",
                table: "AspNetUsers",
                column: "QrlkChatId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_QrlkChat_QrlkChatId",
                table: "AspNetUsers",
                column: "QrlkChatId",
                principalTable: "QrlkChat",
                principalColumn: "Id");
        }
    }
}
