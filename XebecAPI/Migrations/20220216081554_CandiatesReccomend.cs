using Microsoft.EntityFrameworkCore.Migrations;

namespace XebecAPI.Migrations
{
    public partial class CandiatesReccomend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidatesRecommender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    TotalMatch = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatesRecommender", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidatesRecommender_AppUser_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatesRecommender_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesRecommender_AppUserId",
                table: "CandidatesRecommender",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesRecommender_JobId",
                table: "CandidatesRecommender",
                column: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatesRecommender");
        }
    }
}
