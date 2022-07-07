using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smurfs.DataAccess.Migrations
{
    public partial class databaseyenileme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProjectParameters");

            migrationBuilder.DropColumn(
                name: "ProjeGerceklesen",
                table: "ProjectParameters");

            migrationBuilder.DropColumn(
                name: "ProjeKapasite",
                table: "ProjectParameters");

            migrationBuilder.DropColumn(
                name: "ProjeVerimDegeri",
                table: "ProjectParameters");

            migrationBuilder.DropColumn(
                name: "ProjeVerimSonucu",
                table: "ProjectParameters");

            migrationBuilder.DropColumn(
                name: "ProjeVerimYuzdesi",
                table: "ProjectParameters");

            migrationBuilder.DropColumn(
                name: "CallGerceklesen",
                table: "CallParameters");

            migrationBuilder.DropColumn(
                name: "CallKapasite",
                table: "CallParameters");

            migrationBuilder.DropColumn(
                name: "CallVerimDegeri",
                table: "CallParameters");

            migrationBuilder.DropColumn(
                name: "CallVerimSonucu",
                table: "CallParameters");

            migrationBuilder.DropColumn(
                name: "CallVerimYuzdesi",
                table: "CallParameters");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CallParameters");

            migrationBuilder.AddColumn<bool>(
                name: "IsState",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "CallAmount",
                table: "Premiums",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ProjectAmount",
                table: "Premiums",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsState",
                table: "Calls",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "GeneralPremiums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProjectAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CallAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PremiumDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralPremiums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralPremiums_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneralPremiums_UsersId",
                table: "GeneralPremiums",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralPremiums");

            migrationBuilder.DropColumn(
                name: "IsState",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CallAmount",
                table: "Premiums");

            migrationBuilder.DropColumn(
                name: "ProjectAmount",
                table: "Premiums");

            migrationBuilder.DropColumn(
                name: "IsState",
                table: "Calls");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProjectParameters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjeGerceklesen",
                table: "ProjectParameters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjeKapasite",
                table: "ProjectParameters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjeVerimDegeri",
                table: "ProjectParameters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjeVerimSonucu",
                table: "ProjectParameters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjeVerimYuzdesi",
                table: "ProjectParameters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CallGerceklesen",
                table: "CallParameters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CallKapasite",
                table: "CallParameters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CallVerimDegeri",
                table: "CallParameters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CallVerimSonucu",
                table: "CallParameters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CallVerimYuzdesi",
                table: "CallParameters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CallParameters",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
