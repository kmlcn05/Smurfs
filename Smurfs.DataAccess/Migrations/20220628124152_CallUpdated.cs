using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smurfs.DataAccess.Migrations
{
    public partial class CallUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JiraProjectNo",
                table: "Calls",
                newName: "TaskType");

            migrationBuilder.RenameColumn(
                name: "JiraProjectName",
                table: "Calls",
                newName: "Reporter");

            migrationBuilder.RenameColumn(
                name: "CallDate",
                table: "Calls",
                newName: "CallDateResolved");

            migrationBuilder.AddColumn<DateTime>(
                name: "CallDateCreated",
                table: "Calls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CallDateCreated",
                table: "Calls");

            migrationBuilder.RenameColumn(
                name: "TaskType",
                table: "Calls",
                newName: "JiraProjectNo");

            migrationBuilder.RenameColumn(
                name: "Reporter",
                table: "Calls",
                newName: "JiraProjectName");

            migrationBuilder.RenameColumn(
                name: "CallDateResolved",
                table: "Calls",
                newName: "CallDate");
        }
    }
}
