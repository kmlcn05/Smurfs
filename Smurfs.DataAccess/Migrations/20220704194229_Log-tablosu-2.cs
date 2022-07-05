using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smurfs.DataAccess.Migrations
{
    public partial class Logtablosu2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Calls_CallId",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Projects_ProjectId",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_CallId",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_ProjectId",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "CallId",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Logs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CallId",
                table: "Logs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Logs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logs_CallId",
                table: "Logs",
                column: "CallId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ProjectId",
                table: "Logs",
                column: "ProjectId");

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
    }
}
