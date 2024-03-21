namespace IUMS.Application.Features.LMS.CourseQuestions.Queries;
public class QuestionOptionResponse
{
    public int Id { get; set; }
    public int CourseQuestionId { get; set; }
    public string Option { get; set; }
    public bool IsAnswer { get; set; }
}
