using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyEmployee.Data.Migrations
{
    public partial class Changeentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "Experience",
                table: "Employees",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Employees",
                nullable: false,
                defaultValue: 0);
        }
    }
}
