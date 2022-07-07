using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smurfs.DataAccess.Migrations
{
    public partial class DatabaseYenileme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CallStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CallStatusName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DZDStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DZDStatusName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DZDStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Processes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankId = table.Column<int>(type: "int", nullable: true),
                    TaskType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JiraTaskNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CallName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CagriCozumSuresi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CallDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CallPriority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CallDateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CallDateResolved = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CallStatusId = table.Column<int>(type: "int", nullable: true),
                    Appointee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reporter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsState = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calls_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Calls_CallStatus_CallStatusId",
                        column: x => x.CallStatusId,
                        principalTable: "CallStatus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: true),
                    JiraProjectNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JiraTaskNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JiraProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DZDStatusId = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    Developer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Analyst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalManDay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeveloperManDay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnalystManDay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PmManDay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsState = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_DZDStatuses_DZDStatusId",
                        column: x => x.DZDStatusId,
                        principalTable: "DZDStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<byte>(type: "tinyint", nullable: false),
                    FirstLogin = table.Column<byte>(type: "tinyint", nullable: false),
                    DateOfStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    usergroupId = table.Column<int>(type: "int", nullable: true),
                    teamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Teams_teamId",
                        column: x => x.teamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_UserGroups_usergroupId",
                        column: x => x.usergroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CallParameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParametersDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CallCarpani = table.Column<int>(type: "int", nullable: false),
                    CallId = table.Column<int>(type: "int", nullable: true)
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
                    ParametersDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjeCarpani = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: true),
                    Page = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Premiums",
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
                    table.PrimaryKey("PK_Premiums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Premiums_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CallParameters_CallId",
                table: "CallParameters",
                column: "CallId");

            migrationBuilder.CreateIndex(
                name: "IX_Calls_BankId",
                table: "Calls",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Calls_CallStatusId",
                table: "Calls",
                column: "CallStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralPremiums_UsersId",
                table: "GeneralPremiums",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ProcessId",
                table: "Logs",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_UsersId",
                table: "Logs",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Premiums_UsersId",
                table: "Premiums",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectParameters_ProjectId",
                table: "ProjectParameters",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_BankId",
                table: "Projects",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DepartmentId",
                table: "Projects",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DZDStatusId",
                table: "Projects",
                column: "DZDStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_StatusId",
                table: "Projects",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TeamId",
                table: "Projects",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_teamId",
                table: "Users",
                column: "teamId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_usergroupId",
                table: "Users",
                column: "usergroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CallParameters");

            migrationBuilder.DropTable(
                name: "GeneralPremiums");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Premiums");

            migrationBuilder.DropTable(
                name: "ProjectParameters");

            migrationBuilder.DropTable(
                name: "Calls");

            migrationBuilder.DropTable(
                name: "Processes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "CallStatus");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "DZDStatuses");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
