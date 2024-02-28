using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreHero.Boilerplate.Infrastructure.Migrations.ApplicationDb
{
    public partial class AddBatchEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aca_Batches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    FacultyId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    BatchName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BatchNameBN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aca_Batches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aca_Batches_Aca_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Aca_Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Aca_Batches_Aca_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Aca_Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Aca_Batches_Aca_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Aca_Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aca_Batches_DepartmentId",
                table: "Aca_Batches",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Aca_Batches_FacultyId",
                table: "Aca_Batches",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Aca_Batches_ProgramId",
                table: "Aca_Batches",
                column: "ProgramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aca_Batches");
        }
    }
}
