using Microsoft.EntityFrameworkCore.Migrations;

namespace XebecAPI.Migrations
{
    public partial class CreatedRejectedCandidate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RejectedCandidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    UnsuccessfulReasonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RejectedCandidates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RejectedCandidates_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RejectedCandidates_UnsuccessfulReasons_UnsuccessfulReasonId",
                        column: x => x.UnsuccessfulReasonId,
                        principalTable: "UnsuccessfulReasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RejectedCandidates_ApplicationId",
                table: "RejectedCandidates",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_RejectedCandidates_UnsuccessfulReasonId",
                table: "RejectedCandidates",
                column: "UnsuccessfulReasonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RejectedCandidates");
        }
    }
}
