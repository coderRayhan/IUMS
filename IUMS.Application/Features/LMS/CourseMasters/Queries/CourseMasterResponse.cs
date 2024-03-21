using IUMS.Application.Features.LMS.CourseChapters.Queries;
using IUMS.Application.Features.LMS.CourseOutcomes.Queries;
using System.Collections.Generic;

namespace IUMS.Application.Features.LMS.CourseMasters.Queries;
public class CourseMasterResponse : CommonProperties
{
    public int CourseAssignId { get; set; }
    public int PartId { get; set; }
    public int TeacherId { get; set; }
    public string CourseObjective { get; set; }
    public string CourseOutline { get; set; }
    public string VideoUrl { get; set; }
    public string ThumbnailUrl { get; set; }
    public string TextBook { get; set; }
    public string ReferenceBook { get; set; }
    public List<CourseChapterResponse> CourseChapters { get; set; }
    public List<CourseOutcomeResponse> CourseOutcomes { get; set; }
    public List<CourseFAQResponse> CourseFAQs { get; set; }
}
