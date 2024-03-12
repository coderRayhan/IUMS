using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCoreHero.Boilerplate.Infrastructure.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class ChangeTableNameFOrCOurseAssign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseAssigns_Aca_Batches_BatchId",
                table: "CourseAssigns");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseAssigns_Aca_Departments_DepartmentId",
                table: "CourseAssigns");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseAssigns_Aca_Faculties_FacultyId",
                table: "CourseAssigns");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseAssigns_Aca_Programs_ProgramId",
                table: "CourseAssigns");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseAssigns_Aca_Sessions_SessionId",
                table: "CourseAssigns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseAssigns",
                table: "CourseAssigns");

            migrationBuilder.RenameTable(
                name: "CourseAssigns",
                newName: "Aca_CourseAssigns");

            migrationBuilder.RenameIndex(
                name: "IX_CourseAssigns_SessionId",
                table: "Aca_CourseAssigns",
                newName: "IX_Aca_CourseAssigns_SessionId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseAssigns_ProgramId",
                table: "Aca_CourseAssigns",
                newName: "IX_Aca_CourseAssigns_ProgramId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseAssigns_FacultyId",
                table: "Aca_CourseAssigns",
                newName: "IX_Aca_CourseAssigns_FacultyId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseAssigns_DepartmentId",
                table: "Aca_CourseAssigns",
                newName: "IX_Aca_CourseAssigns_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseAssigns_BatchId",
                table: "Aca_CourseAssigns",
                newName: "IX_Aca_CourseAssigns_BatchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aca_CourseAssigns",
                table: "Aca_CourseAssigns",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Aca_CourseAssigns_Aca_Batches_BatchId",
                table: "Aca_CourseAssigns",
                column: "BatchId",
                principalTable: "Aca_Batches",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Aca_CourseAssigns_Aca_Departments_DepartmentId",
                table: "Aca_CourseAssigns",
                column: "DepartmentId",
                principalTable: "Aca_Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Aca_CourseAssigns_Aca_Faculties_FacultyId",
                table: "Aca_CourseAssigns",
                column: "FacultyId",
                principalTable: "Aca_Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Aca_CourseAssigns_Aca_Programs_ProgramId",
                table: "Aca_CourseAssigns",
                column: "ProgramId",
                principalTable: "Aca_Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Aca_CourseAssigns_Aca_Sessions_SessionId",
                table: "Aca_CourseAssigns",
                column: "SessionId",
                principalTable: "Aca_Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aca_CourseAssigns_Aca_Batches_BatchId",
                table: "Aca_CourseAssigns");

            migrationBuilder.DropForeignKey(
                name: "FK_Aca_CourseAssigns_Aca_Departments_DepartmentId",
                table: "Aca_CourseAssigns");

            migrationBuilder.DropForeignKey(
                name: "FK_Aca_CourseAssigns_Aca_Faculties_FacultyId",
                table: "Aca_CourseAssigns");

            migrationBuilder.DropForeignKey(
                name: "FK_Aca_CourseAssigns_Aca_Programs_ProgramId",
                table: "Aca_CourseAssigns");

            migrationBuilder.DropForeignKey(
                name: "FK_Aca_CourseAssigns_Aca_Sessions_SessionId",
                table: "Aca_CourseAssigns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aca_CourseAssigns",
                table: "Aca_CourseAssigns");

            migrationBuilder.RenameTable(
                name: "Aca_CourseAssigns",
                newName: "CourseAssigns");

            migrationBuilder.RenameIndex(
                name: "IX_Aca_CourseAssigns_SessionId",
                table: "CourseAssigns",
                newName: "IX_CourseAssigns_SessionId");

            migrationBuilder.RenameIndex(
                name: "IX_Aca_CourseAssigns_ProgramId",
                table: "CourseAssigns",
                newName: "IX_CourseAssigns_ProgramId");

            migrationBuilder.RenameIndex(
                name: "IX_Aca_CourseAssigns_FacultyId",
                table: "CourseAssigns",
                newName: "IX_CourseAssigns_FacultyId");

            migrationBuilder.RenameIndex(
                name: "IX_Aca_CourseAssigns_DepartmentId",
                table: "CourseAssigns",
                newName: "IX_CourseAssigns_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Aca_CourseAssigns_BatchId",
                table: "CourseAssigns",
                newName: "IX_CourseAssigns_BatchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseAssigns",
                table: "CourseAssigns",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAssigns_Aca_Batches_BatchId",
                table: "CourseAssigns",
                column: "BatchId",
                principalTable: "Aca_Batches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAssigns_Aca_Departments_DepartmentId",
                table: "CourseAssigns",
                column: "DepartmentId",
                principalTable: "Aca_Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAssigns_Aca_Faculties_FacultyId",
                table: "CourseAssigns",
                column: "FacultyId",
                principalTable: "Aca_Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAssigns_Aca_Programs_ProgramId",
                table: "CourseAssigns",
                column: "ProgramId",
                principalTable: "Aca_Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAssigns_Aca_Sessions_SessionId",
                table: "CourseAssigns",
                column: "SessionId",
                principalTable: "Aca_Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
