using Microsoft.EntityFrameworkCore.Migrations;

namespace vhec.SkillInventory.DAL.Migrations
{
    public partial class Dbv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "skills",
                newName: "DayCreated");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DayCreated",
                table: "skills",
                newName: "CreateDate");
        }
    }
}
