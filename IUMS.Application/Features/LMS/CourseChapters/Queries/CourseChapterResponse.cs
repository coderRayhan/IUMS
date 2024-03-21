using IUMS.Application.Features.LMS.ChapterClasses.Queries;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IUMS.Application.Features.LMS.CourseChapters.Queries;
public class CourseChapterResponse
{
    public int Id { get; set; }
    public int CourseMasterId { get; set; }
    public int ChapterNo { get; set; }
    [StringLength(100)]
    public string Title { get; set; }
    public decimal Duration { get; set; }
    [StringLength(500)]
    public string Description { get; set; }
    public List<ChapterClassResponse> ChapterClasses { get; set; } = new();
}
public class GetChapterListByCourseMasterResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
}
