using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCoreHero.Boilerplate.Infrastructure.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class AddStudentInfosEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Std_StudentBasicInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassRollNo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RegistrationNumber = table.Column<int>(type: "int", nullable: false),
                    DateOfAdmission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FatherMobileNo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MotherMobileNo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    ReligionId = table.Column<int>(type: "int", nullable: false),
                    MaritalStatusId = table.Column<int>(type: "int", nullable: false),
                    BloodGroupId = table.Column<int>(type: "int", nullable: false),
                    VillageName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    UpazillaId = table.Column<int>(type: "int", nullable: false),
                    PostOffice = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FacultyId = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    BatchId = table.Column<int>(type: "int", nullable: false),
                    SemesterId = table.Column<int>(type: "int", nullable: false),
                    StudentImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRegistered = table.Column<int>(type: "int", nullable: false),
                    AdviserId = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    IsAdviserAssigned = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AcademicSemesterId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Std_StudentBasicInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Std_StudentEducationalInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentBasicInfoId = table.Column<int>(type: "int", nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: false),
                    PassingYear = table.Column<int>(type: "int", nullable: false),
                    InstitutionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RollNumber = table.Column<long>(type: "bigint", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    ExamResult = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Std_StudentEducationalInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Std_StudentEducationalInfos_Std_StudentBasicInfos_StudentBasicInfoId",
                        column: x => x.StudentBasicInfoId,
                        principalTable: "Std_StudentBasicInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Std_StudentEducationalInfos_StudentBasicInfoId",
                table: "Std_StudentEducationalInfos",
                column: "StudentBasicInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Std_StudentEducationalInfos");

            migrationBuilder.DropTable(
                name: "Std_StudentBasicInfos");
        }
    }
}
