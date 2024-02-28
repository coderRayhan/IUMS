using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreHero.Boilerplate.Infrastructure.Migrations.ApplicationDb
{
    public partial class AddProgramEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aca_Programs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProgramNameBN = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CreditPoints = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    YearDuration = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aca_Programs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aca_Programs_Aca_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Aca_Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aca_Programs_DepartmentId",
                table: "Aca_Programs",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aca_Programs");
        }
    }
}
