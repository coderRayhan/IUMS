using IUMS.Application.Enums;
using IUMS.Application.Features.LMS.CourseMasters.Queries;
using System.Collections.Generic;

namespace IUMS.Web.Areas.LMS.Models;

public class CourseQuestionViewModel : CommonProperties
{
    public int? CourseChapterId { get; set; }
    public int QuestionTypeId { get; set; }
    public QuestionType QuestionType { get; set; }
    public bool IsWritten { get; set; }
    public string Question { get; set; }
    public decimal Mark { get; set; }
    public string Answer { get; set; }
    public bool IsChaperQuestion { get; set; }
    public int CourseQuestionId { get; set; }
    public List<QuestionOptionViewModel> QuestionOptions { get; set; } = new();
}
