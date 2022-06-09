using Microsoft.EntityFrameworkCore.Migrations;

namespace XebecAPI.Migrations
{
    public partial class Documents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentUrl",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "DocumentName",
                table: "Documents",
                newName: "UniversityTranscript");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalCert1",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalCert2",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalCert3",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CV",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MatricCertificate",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalCert1",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "AdditionalCert2",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "AdditionalCert3",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "CV",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "MatricCertificate",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "UniversityTranscript",
                table: "Documents",
                newName: "DocumentName");

            migrationBuilder.AddColumn<string>(
                name: "DocumentUrl",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
