using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCoreHero.Boilerplate.Infrastructure.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class AddCourseAssignEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseAssigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    FacultyId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    AcademicSemesterId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    TotalMarks = table.Column<double>(type: "float", nullable: false),
                    ContinuousAssesment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TermFinal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PassMark = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BatchId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseAssigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseAssigns_Aca_Batches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Aca_Batches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CourseAssigns_Aca_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Aca_Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CourseAssigns_Aca_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Aca_Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CourseAssigns_Aca_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Aca_Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CourseAssigns_Aca_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Aca_Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssigns_BatchId",
                table: "CourseAssigns",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssigns_DepartmentId",
                table: "CourseAssigns",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssigns_FacultyId",
                table: "CourseAssigns",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssigns_ProgramId",
                table: "CourseAssigns",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssigns_SessionId",
                table: "CourseAssigns",
                column: "SessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseAssigns");
        }
    }
}
