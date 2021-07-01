using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace vhec.SkillInventory.DAL.Migrations
{
    public partial class DbV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    JobPosition = table.Column<int>(type: "integer", nullable: false),
                    DayCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    DayCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "detailSkills",
                columns: table => new
                {
                    IdDetail = table.Column<int>(type: "integer", nullable: false),
                    EmployeeID = table.Column<Guid>(type: "uuid", nullable: false),
                    SkillID = table.Column<int>(type: "integer", nullable: false),
                    Experience = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detailSkills", x => new { x.IdDetail, x.EmployeeID, x.SkillID });
                    table.ForeignKey(
                        name: "FK_detailSkills_employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detailSkills_skills_SkillID",
                        column: x => x.SkillID,
                        principalTable: "skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_detailSkills_EmployeeID",
                table: "detailSkills",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_detailSkills_SkillID",
                table: "detailSkills",
                column: "SkillID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detailSkills");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "skills");
        }
    }
}
