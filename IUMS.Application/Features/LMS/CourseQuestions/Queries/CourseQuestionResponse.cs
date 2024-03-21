using IUMS.Application.Enums;
using System.Collections.Generic;

namespace IUMS.Application.Features.LMS.CourseQuestions.Queries;
public class CourseQuestionResponse
{
    public int Id { get; set; }
    public int CourseMasterId { get; set; }
    public int? CourseChapterId { get; set; }
    public int QuestionTypeId { get; set; }
    public QuestionType QuestionType { get; set; }
    public bool IsWritten { get; set; }
    public string Question { get; set; }
    public decimal Mark { get; set; }
    public string Answer { get; set; }
    public bool IsChaperQuestion { get; set; }
    public int CourseQuestionId { get; set; }
    public List<QuestionOptionResponse> QuestionOptions { get; set; } = new();
}
public class CourseFromLMSCourseMasterResponse
{
    public int Id { get; set; }
    public string CourseName { get; set; }
    public int AdmissionYearId { get; set; }
    public int FacultyId { get; set; }
    public int DepartmentId { get; set; }
    public int ProgramId { get; set; }
    public int SemesterId { get; set; }
}
