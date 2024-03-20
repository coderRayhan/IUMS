namespace IUMS.Application.Features.LMS.CourseMasters.Queries;
public class CourseFAQResponse
{
    public int Id { get; set; }
    public int CourseConfigId { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
}
