using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smurfs.DataAccess.Migrations
{
    public partial class FirstLogin2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "FirstLogin",
                table: "Users",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FirstLogin",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }
    }
}
