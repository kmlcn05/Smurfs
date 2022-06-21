using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smurfs.DataAccess.Migrations
{
    public partial class entityduzenleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Logs_LogId",
                table: "Calls");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Projects_ProjectId",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Premiums_premiumId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_premiumId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Calls_LogId",
                table: "Calls");

            migrationBuilder.DropColumn(
                name: "premiumId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LogId",
                table: "Calls");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Logs",
                newName: "ProjectsId");

            migrationBuilder.RenameIndex(
                name: "IX_Logs_ProjectId",
                table: "Logs",
                newName: "IX_Logs_ProjectsId");

            migrationBuilder.AddColumn<DateTime>(
                name: "PremiumDate",
                table: "Premiums",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Premiums",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CallsId",
                table: "Logs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CallParameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParametersDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CallId = table.Column<int>(type: "int", nullable: true),
                    CallCarpani = table.Column<int>(type: "int", nullable: false),
                    CallKapasite = table.Column<int>(type: "int", nullable: false),
                    CallGerceklesen = table.Column<int>(type: "int", nullable: false),
                    CallVerimYuzdesi = table.Column<int>(type: "int", nullable: false),
                    CallVerimDegeri = table.Column<int>(type: "int", nullable: false),
                    CallVerimSonucu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CallParameters_Calls_CallId",
                        column: x => x.CallId,
                        principalTable: "Calls",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectParameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParametersDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    ProjeCarpani = table.Column<int>(type: "int", nullable: false),
                    ProjeKapasite = table.Column<int>(type: "int", nullable: false),
                    ProjeGerceklesen = table.Column<int>(type: "int", nullable: false),
                    ProjeVerimYuzdesi = table.Column<int>(type: "int", nullable: false),
                    ProjeVerimDegeri = table.Column<int>(type: "int", nullable: false),
                    ProjeVerimSonucu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectParameters_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Premiums_UsersId",
                table: "Premiums",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_CallsId",
                table: "Logs",
                column: "CallsId");

            migrationBuilder.CreateIndex(
                name: "IX_CallParameters_CallId",
                table: "CallParameters",
                column: "CallId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectParameters_ProjectId",
                table: "ProjectParameters",
                column: "ProjectId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Premiums_Users_UsersId",
                table: "Premiums",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Calls_CallsId",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Projects_ProjectsId",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Premiums_Users_UsersId",
                table: "Premiums");

            migrationBuilder.DropTable(
                name: "CallParameters");

            migrationBuilder.DropTable(
                name: "ProjectParameters");

            migrationBuilder.DropIndex(
                name: "IX_Premiums_UsersId",
                table: "Premiums");

            migrationBuilder.DropIndex(
                name: "IX_Logs_CallsId",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "PremiumDate",
                table: "Premiums");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Premiums");

            migrationBuilder.DropColumn(
                name: "CallsId",
                table: "Logs");

            migrationBuilder.RenameColumn(
                name: "ProjectsId",
                table: "Logs",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Logs_ProjectsId",
                table: "Logs",
                newName: "IX_Logs_ProjectId");

            migrationBuilder.AddColumn<int>(
                name: "premiumId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LogId",
                table: "Calls",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_premiumId",
                table: "Users",
                column: "premiumId");

            migrationBuilder.CreateIndex(
                name: "IX_Calls_LogId",
                table: "Calls",
                column: "LogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Logs_LogId",
                table: "Calls",
                column: "LogId",
                principalTable: "Logs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Projects_ProjectId",
                table: "Logs",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Premiums_premiumId",
                table: "Users",
                column: "premiumId",
                principalTable: "Premiums",
                principalColumn: "Id");
        }
    }
}
