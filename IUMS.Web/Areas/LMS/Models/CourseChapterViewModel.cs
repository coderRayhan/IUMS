using System.Collections.Generic;

namespace IUMS.Web.Areas.LMS.Models;

public class CourseChapterViewModel
{
    public int Id { get; set; }
    public int CourseMasterId { get; set; }
    public int ChapterNo { get; set; }
    public string Title { get; set; }
    public decimal Duration { get; set; } = 0;
    public string Description { get; set; }
    public List<ChapterClassViewModel> ChapterClasses { get; set; }
}
