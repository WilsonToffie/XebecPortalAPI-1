using Microsoft.EntityFrameworkCore.Migrations;

namespace XebecAPI.Migrations
{
    public partial class CollaboratorQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CollaboratorQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    QuestionnaireHrFormId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaboratorQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollaboratorQuestions_AppUser_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollaboratorQuestions_QuestionnaireHRForms_QuestionnaireHrFormId",
                        column: x => x.QuestionnaireHrFormId,
                        principalTable: "QuestionnaireHRForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollaboratorQuestions_AppUserId",
                table: "CollaboratorQuestions",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CollaboratorQuestions_QuestionnaireHrFormId",
                table: "CollaboratorQuestions",
                column: "QuestionnaireHrFormId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollaboratorQuestions");
        }
    }
}
