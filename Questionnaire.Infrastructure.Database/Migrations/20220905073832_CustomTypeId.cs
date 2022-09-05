using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Questionnaire.Infrastructure.Database.Migrations
{
    public partial class CustomTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Structure_Property_ParentPropertyId",
                table: "Structure");

            migrationBuilder.DropIndex(
                name: "IX_Structure_ParentPropertyId",
                table: "Structure");

            migrationBuilder.DropColumn(
                name: "ParentPropertyId",
                table: "Structure");

            migrationBuilder.AddColumn<int>(
                name: "CustomTypeId",
                table: "Property",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Property_CustomTypeId",
                table: "Property",
                column: "CustomTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Structure_CustomTypeId",
                table: "Property",
                column: "CustomTypeId",
                principalTable: "Structure",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_Structure_CustomTypeId",
                table: "Property");

            migrationBuilder.DropIndex(
                name: "IX_Property_CustomTypeId",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "CustomTypeId",
                table: "Property");

            migrationBuilder.AddColumn<int>(
                name: "ParentPropertyId",
                table: "Structure",
                type: "integer",
                nullable: true,
                defaultValueSql: "null");

            migrationBuilder.CreateIndex(
                name: "IX_Structure_ParentPropertyId",
                table: "Structure",
                column: "ParentPropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Structure_Property_ParentPropertyId",
                table: "Structure",
                column: "ParentPropertyId",
                principalTable: "Property",
                principalColumn: "Id");
        }
    }
}
