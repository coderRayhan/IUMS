using IUMS.Application.Features.LMS.CourseMasters.Queries;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace IUMS.Web.Areas.LMS.Models;

public class CourseMasterViewModel : CommonProperties
{
    public int CourseAssignId { get; set; }
    public int PartId { get; set; }
    public int TeacherId { get; set; }
    public string CourseObjective { get; set; }
    public string CourseOutline { get; set; }
    public IFormFile Video { get; set; }
    public string VideoUrl { get; set; }
    public IFormFile Thumbnail { get; set; }
    public string ThumbnailUrl { get; set; }
    public string TextBook { get; set; }
    public string ReferenceBook { get; set; }
    public List<CourseChapterViewModel> CourseChapters { get; set; } = new();
    public List<CourseOutcomeViewModel> CourseOutcomes { get; set; } = new();
    public List<CourseFAQViewModel> CourseFAQs { get; set; } = new();
}
