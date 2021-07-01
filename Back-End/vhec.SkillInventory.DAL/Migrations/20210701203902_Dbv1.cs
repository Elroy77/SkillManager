using Microsoft.EntityFrameworkCore.Migrations;

namespace vhec.SkillInventory.DAL.Migrations
{
    public partial class Dbv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Experience",
                table: "skills");

            migrationBuilder.AddColumn<int>(
                name: "Experience",
                table: "employees",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Experience",
                table: "employees");

            migrationBuilder.AddColumn<int>(
                name: "Experience",
                table: "skills",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
