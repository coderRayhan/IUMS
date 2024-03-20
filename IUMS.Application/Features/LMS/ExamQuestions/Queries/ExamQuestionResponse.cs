namespace IUMS.Application.Features.LMS.ExamQuestions.Queries;
public class ExamQuestionResponse
{
    public int Id { get; set; }
    public int CourseExamId { get; set; }
    public int CourseQuestionId { get; set; }
    public bool IsRequired { get; set; }
    public int CourseChapterId { get; set; }
    public string Question { get; set; }
    public int QuestionTypeId { get; set; }
    public bool IsSelected { get; set; }
    public decimal Mark { get; set; }
}
