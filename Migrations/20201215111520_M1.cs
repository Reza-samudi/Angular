using Microsoft.EntityFrameworkCore.Migrations;

namespace Amoozeshyar.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Professors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Managers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Firstname",
                table: "Managers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "Managers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "Managers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Managers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Managers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "gender",
                table: "Managers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Interns",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "Firstname",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Interns");
        }
    }
}
