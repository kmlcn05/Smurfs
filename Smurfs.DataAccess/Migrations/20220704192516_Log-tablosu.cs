using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smurfs.DataAccess.Migrations
{
    public partial class Logtablosu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Calls_CallsId",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Projects_ProjectsId",
                table: "Logs");

            migrationBuilder.RenameColumn(
                name: "ProjectsId",
                table: "Logs",
                newName: "ProjectId");

            migrationBuilder.RenameColumn(
                name: "CallsId",
                table: "Logs",
                newName: "CallId");

            migrationBuilder.RenameIndex(
                name: "IX_Logs_ProjectsId",
                table: "Logs",
                newName: "IX_Logs_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Logs_CallsId",
                table: "Logs",
                newName: "IX_Logs_CallId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Calls_CallId",
                table: "Logs",
                column: "CallId",
                principalTable: "Calls",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Projects_ProjectId",
                table: "Logs",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Calls_CallId",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Projects_ProjectId",
                table: "Logs");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Logs",
                newName: "ProjectsId");

            migrationBuilder.RenameColumn(
                name: "CallId",
                table: "Logs",
                newName: "CallsId");

            migrationBuilder.RenameIndex(
                name: "IX_Logs_ProjectId",
                table: "Logs",
                newName: "IX_Logs_ProjectsId");

            migrationBuilder.RenameIndex(
                name: "IX_Logs_CallId",
                table: "Logs",
                newName: "IX_Logs_CallsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Calls_CallsId",
                table: "Logs",
                column: "CallsId",
                principalTable: "Calls",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Projects_ProjectsId",
                table: "Logs",
                column: "ProjectsId",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
