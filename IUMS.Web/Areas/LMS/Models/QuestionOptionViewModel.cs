namespace IUMS.Web.Areas.LMS.Models;

public class QuestionOptionViewModel
{
    public int Id { get; set; }
    public int CourseQuestionId { get; set; }
    public string Option { get; set; }
    public bool IsAnswer { get; set; }
}
