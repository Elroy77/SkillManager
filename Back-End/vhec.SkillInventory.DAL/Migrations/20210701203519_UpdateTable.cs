using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vhec.SkillInventory.DAL.Migrations
{
    public partial class UpdateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SkillId",
                table: "employees",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "skills",
                columns: table => new
                {
                    SkillId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Experience = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skills", x => x.SkillId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employees_SkillId",
                table: "employees",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_skills_SkillId",
                table: "employees",
                column: "SkillId",
                principalTable: "skills",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_skills_SkillId",
                table: "employees");

            migrationBuilder.DropTable(
                name: "skills");

            migrationBuilder.DropIndex(
                name: "IX_employees_SkillId",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "employees");
        }
    }
}
