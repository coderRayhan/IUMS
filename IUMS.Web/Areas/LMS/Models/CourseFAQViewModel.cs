namespace IUMS.Web.Areas.LMS.Models;

public class CourseFAQViewModel
{
    public int Id { get; set; }
    public int CourseConfigId { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
}
