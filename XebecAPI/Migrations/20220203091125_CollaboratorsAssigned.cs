using Microsoft.EntityFrameworkCore.Migrations;

namespace XebecAPI.Migrations
{
    public partial class CollaboratorsAssigned : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CollaboratorsAssigneds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaboratorsAssigneds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollaboratorsAssigneds_AppUser_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollaboratorsAssigneds_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollaboratorsAssigneds_AppUserId",
                table: "CollaboratorsAssigneds",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CollaboratorsAssigneds_JobId",
                table: "CollaboratorsAssigneds",
                column: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollaboratorsAssigneds");
        }
    }
}
