using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreHero.Boilerplate.Infrastructure.Migrations.ApplicationDb
{
    public partial class ChangeDepartmentEntityName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Aca_Faculties_FacultyId",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Aca_Departments");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_FacultyId",
                table: "Aca_Departments",
                newName: "IX_Aca_Departments_FacultyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aca_Departments",
                table: "Aca_Departments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Aca_Departments_Aca_Faculties_FacultyId",
                table: "Aca_Departments",
                column: "FacultyId",
                principalTable: "Aca_Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aca_Departments_Aca_Faculties_FacultyId",
                table: "Aca_Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aca_Departments",
                table: "Aca_Departments");

            migrationBuilder.RenameTable(
                name: "Aca_Departments",
                newName: "Departments");

            migrationBuilder.RenameIndex(
                name: "IX_Aca_Departments_FacultyId",
                table: "Departments",
                newName: "IX_Departments_FacultyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Aca_Faculties_FacultyId",
                table: "Departments",
                column: "FacultyId",
                principalTable: "Aca_Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
