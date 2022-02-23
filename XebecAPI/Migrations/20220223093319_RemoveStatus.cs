using Microsoft.EntityFrameworkCore.Migrations;

namespace XebecAPI.Migrations
{
    public partial class RemoveStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationPhasesHelpers_Statuses_StatusId",
                table: "ApplicationPhasesHelpers");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationPhasesHelpers_StatusId",
                table: "ApplicationPhasesHelpers");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "ApplicationPhasesHelpers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "ApplicationPhasesHelpers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationPhasesHelpers_StatusId",
                table: "ApplicationPhasesHelpers",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationPhasesHelpers_Statuses_StatusId",
                table: "ApplicationPhasesHelpers",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
