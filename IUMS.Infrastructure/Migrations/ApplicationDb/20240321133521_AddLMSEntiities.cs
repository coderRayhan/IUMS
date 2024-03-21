using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCoreHero.Boilerplate.Infrastructure.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class AddLMSEntiities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LMS_CourseMasters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseAssignId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    CourseObjective = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseOutline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TextBook = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ReferenceBook = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LMS_CourseMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LMS_CourseMasters_Aca_CourseAssigns_CourseAssignId",
                        column: x => x.CourseAssignId,
                        principalTable: "Aca_CourseAssigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LMS_HostConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    HostName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ZoomId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ZoomUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientSecret = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LMS_HostConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LMS_StudentEvaluation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseMasterId = table.Column<int>(type: "int", nullable: false),
                    ChapterId = table.Column<int>(type: "int", nullable: false),
                    ChapterExamId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAssignment = table.Column<bool>(type: "bit", nullable: false),
                    TotalObtainMarks = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubmitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSubmitted = table.Column<bool>(type: "bit", nullable: false),
                    SubmittedBy = table.Column<int>(type: "int", nullable: false),
                    IsEvaluated = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LMS_StudentEvaluation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LMS_ZoomClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseMasterId = table.Column<int>(type: "int", nullable: false),
                    CourseChapterId = table.Column<int>(type: "int", nullable: false),
                    ChapterClassId = table.Column<int>(type: "int", nullable: false),
                    HostConfigId = table.Column<int>(type: "int", nullable: false),
                    SessionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Duration = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LMS_ZoomClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LMS_CourseChapters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseMasterId = table.Column<int>(type: "int", nullable: false),
                    ChapterNo = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Duration = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LMS_CourseChapters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LMS_CourseChapters_LMS_CourseMasters_CourseMasterId",
                        column: x => x.CourseMasterId,
                        principalTable: "LMS_CourseMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LMS_CourseExams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseMasterId = table.Column<int>(type: "int", nullable: false),
                    CourseChapterId = table.Column<int>(type: "int", nullable: false),
                    ChapterClassId = table.Column<int>(type: "int", nullable: false),
                    FollowedByChapterId = table.Column<int>(type: "int", nullable: false),
                    ExamTypeId = table.Column<int>(type: "int", nullable: false),
                    ExamNameId = table.Column<int>(type: "int", nullable: false),
                    NoOfQuestions = table.Column<int>(type: "int", nullable: false),
                    QuesToBeAnswered = table.Column<int>(type: "int", nullable: false),
                    TotalMarks = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PassMark = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Duration = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AssignmentDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignmentUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LMS_CourseExams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LMS_CourseExams_LMS_CourseMasters_CourseMasterId",
                        column: x => x.CourseMasterId,
                        principalTable: "LMS_CourseMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LMS_CourseFAQs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseMasterId = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LMS_CourseFAQs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LMS_CourseFAQs_LMS_CourseMasters_CourseMasterId",
                        column: x => x.CourseMasterId,
                        principalTable: "LMS_CourseMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LMS_CourseOutcomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseMasterId = table.Column<int>(type: "int", nullable: false),
                    Outcome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Serial = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LMS_CourseOutcomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LMS_CourseOutcomes_LMS_CourseMasters_CourseMasterId",
                        column: x => x.CourseMasterId,
                        principalTable: "LMS_CourseMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LMS_CourseQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseMasterId = table.Column<int>(type: "int", nullable: false),
                    CourseChapterId = table.Column<int>(type: "int", nullable: true),
                    QuestionTypeId = table.Column<int>(type: "int", nullable: false),
                    IsWritten = table.Column<bool>(type: "bit", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mark = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsChaperQuestion = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LMS_CourseQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LMS_CourseQuestions_LMS_CourseMasters_CourseMasterId",
                        column: x => x.CourseMasterId,
                        principalTable: "LMS_CourseMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LMS_StudentEvaluationDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MCQAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentEvaluationId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LMS_StudentEvaluationDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LMS_StudentEvaluationDetail_LMS_StudentEvaluation_StudentEvaluationId",
                        column: x => x.StudentEvaluationId,
                        principalTable: "LMS_StudentEvaluation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LMS_ChapterClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseChapterId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClassTypeId = table.Column<int>(type: "int", nullable: false),
                    FileTypeId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ContentUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsClassOrExam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HostConfigId = table.Column<int>(type: "int", nullable: false),
                    MeetingId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Join_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Start_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LMS_ChapterClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LMS_ChapterClasses_LMS_CourseChapters_CourseChapterId",
                        column: x => x.CourseChapterId,
                        principalTable: "LMS_CourseChapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LMS_ExamQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseExamId = table.Column<int>(type: "int", nullable: false),
                    CourseQuestionId = table.Column<int>(type: "int", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LMS_ExamQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LMS_ExamQuestions_LMS_CourseExams_CourseExamId",
                        column: x => x.CourseExamId,
                        principalTable: "LMS_CourseExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LMS_QuestionOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseQuestionId = table.Column<int>(type: "int", nullable: false),
                    Option = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAnswer = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LMS_QuestionOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LMS_QuestionOptions_LMS_CourseQuestions_CourseQuestionId",
                        column: x => x.CourseQuestionId,
                        principalTable: "LMS_CourseQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LMS_ChapterClasses_CourseChapterId",
                table: "LMS_ChapterClasses",
                column: "CourseChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_LMS_CourseChapters_CourseMasterId",
                table: "LMS_CourseChapters",
                column: "CourseMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_LMS_CourseExams_CourseMasterId",
                table: "LMS_CourseExams",
                column: "CourseMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_LMS_CourseFAQs_CourseMasterId",
                table: "LMS_CourseFAQs",
                column: "CourseMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_LMS_CourseMasters_CourseAssignId",
                table: "LMS_CourseMasters",
                column: "CourseAssignId");

            migrationBuilder.CreateIndex(
                name: "IX_LMS_CourseOutcomes_CourseMasterId",
                table: "LMS_CourseOutcomes",
                column: "CourseMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_LMS_CourseQuestions_CourseMasterId",
                table: "LMS_CourseQuestions",
                column: "CourseMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_LMS_ExamQuestions_CourseExamId",
                table: "LMS_ExamQuestions",
                column: "CourseExamId");

            migrationBuilder.CreateIndex(
                name: "IX_LMS_QuestionOptions_CourseQuestionId",
                table: "LMS_QuestionOptions",
                column: "CourseQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_LMS_StudentEvaluationDetail_StudentEvaluationId",
                table: "LMS_StudentEvaluationDetail",
                column: "StudentEvaluationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LMS_ChapterClasses");

            migrationBuilder.DropTable(
                name: "LMS_CourseFAQs");

            migrationBuilder.DropTable(
                name: "LMS_CourseOutcomes");

            migrationBuilder.DropTable(
                name: "LMS_ExamQuestions");

            migrationBuilder.DropTable(
                name: "LMS_HostConfigs");

            migrationBuilder.DropTable(
                name: "LMS_QuestionOptions");

            migrationBuilder.DropTable(
                name: "LMS_StudentEvaluationDetail");

            migrationBuilder.DropTable(
                name: "LMS_ZoomClasses");

            migrationBuilder.DropTable(
                name: "LMS_CourseChapters");

            migrationBuilder.DropTable(
                name: "LMS_CourseExams");

            migrationBuilder.DropTable(
                name: "LMS_CourseQuestions");

            migrationBuilder.DropTable(
                name: "LMS_StudentEvaluation");

            migrationBuilder.DropTable(
                name: "LMS_CourseMasters");
        }
    }
}
