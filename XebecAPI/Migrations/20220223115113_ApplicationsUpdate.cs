using Microsoft.EntityFrameworkCore.Migrations;

namespace XebecAPI.Migrations
{
    public partial class ApplicationsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationPhaseId",
                table: "Applications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationPhaseId",
                table: "ApplicationPhases",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicationPhaseId",
                table: "Applications",
                column: "ApplicationPhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationPhases_ApplicationPhaseId",
                table: "ApplicationPhases",
                column: "ApplicationPhaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationPhases_ApplicationPhases_ApplicationPhaseId",
                table: "ApplicationPhases",
                column: "ApplicationPhaseId",
                principalTable: "ApplicationPhases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_ApplicationPhases_ApplicationPhaseId",
                table: "Applications",
                column: "ApplicationPhaseId",
                principalTable: "ApplicationPhases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationPhases_ApplicationPhases_ApplicationPhaseId",
                table: "ApplicationPhases");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_ApplicationPhases_ApplicationPhaseId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_ApplicationPhaseId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationPhases_ApplicationPhaseId",
                table: "ApplicationPhases");

            migrationBuilder.DropColumn(
                name: "ApplicationPhaseId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ApplicationPhaseId",
                table: "ApplicationPhases");
        }
    }
}
