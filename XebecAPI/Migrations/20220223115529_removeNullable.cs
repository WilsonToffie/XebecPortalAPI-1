using Microsoft.EntityFrameworkCore.Migrations;

namespace XebecAPI.Migrations
{
    public partial class removeNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_ApplicationPhases_ApplicationPhaseId",
                table: "Applications");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationPhaseId",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_ApplicationPhases_ApplicationPhaseId",
                table: "Applications",
                column: "ApplicationPhaseId",
                principalTable: "ApplicationPhases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_ApplicationPhases_ApplicationPhaseId",
                table: "Applications");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationPhaseId",
                table: "Applications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_ApplicationPhases_ApplicationPhaseId",
                table: "Applications",
                column: "ApplicationPhaseId",
                principalTable: "ApplicationPhases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
