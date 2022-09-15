using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Questionnaire.Infrastructure.Database.Migrations
{
    public partial class CascadeDeleting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_Structure_CustomTypeId",
                table: "Property");

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Structure_CustomTypeId",
                table: "Property",
                column: "CustomTypeId",
                principalTable: "Structure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_Structure_CustomTypeId",
                table: "Property");

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Structure_CustomTypeId",
                table: "Property",
                column: "CustomTypeId",
                principalTable: "Structure",
                principalColumn: "Id");
        }
    }
}
