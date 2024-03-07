using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCoreHero.Boilerplate.Infrastructure.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class AddCourseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aca_Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CreditHour = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConductHour = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CourseTypeId = table.Column<int>(type: "int", nullable: false),
                    TotalClass = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aca_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aca_Courses_Aca_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Aca_Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aca_Courses_ProgramId",
                table: "Aca_Courses",
                column: "ProgramId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aca_Courses");
        }
    }
}
