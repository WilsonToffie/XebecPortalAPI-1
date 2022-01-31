using Microsoft.EntityFrameworkCore.Migrations;

namespace XebecAPI.Migrations
{
    public partial class AnswerTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnswerTypeId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnswerTypeId",
                table: "QuestionnaireHRForms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AnswerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_AnswerTypeId",
                table: "Questions",
                column: "AnswerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireHRForms_AnswerTypeId",
                table: "QuestionnaireHRForms",
                column: "AnswerTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionnaireHRForms_AnswerTypes_AnswerTypeId",
                table: "QuestionnaireHRForms",
                column: "AnswerTypeId",
                principalTable: "AnswerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_AnswerTypes_AnswerTypeId",
                table: "Questions",
                column: "AnswerTypeId",
                principalTable: "AnswerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionnaireHRForms_AnswerTypes_AnswerTypeId",
                table: "QuestionnaireHRForms");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_AnswerTypes_AnswerTypeId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "AnswerTypes");

            migrationBuilder.DropIndex(
                name: "IX_Questions_AnswerTypeId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_QuestionnaireHRForms_AnswerTypeId",
                table: "QuestionnaireHRForms");

            migrationBuilder.DropColumn(
                name: "AnswerTypeId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "AnswerTypeId",
                table: "QuestionnaireHRForms");
        }
    }
}
