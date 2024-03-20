using IUMS.Application.Features.LMS.CourseMasters.Queries;
using Microsoft.AspNetCore.Http;
using System;

namespace IUMS.Web.Areas.LMS.Models;

public class ChapterClassViewModel : CommonProperties
{
    public int CourseChapterId { get; set; }
    public string Title { get; set; }
    public decimal Duration { get; set; }
    //public LMSClassType ClassTypeId { get; set; }
    public int ClassTypeId { get; set; }
    //public LMSFileType FileTypeId { get; set; }
    public int FileTypeId { get; set; }
    public DateTime? StartDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public DateTime? EndDate { get; set; }
    public TimeSpan EndTime { get; set; }
    public IFormFile Content { get; set; }
    public string ContentUrl { get; set; }
    public string CourseObjective { get; set; }
    public string CourseOutline { get; set; }
    public string ChapterTitle { get; set; }
    public int ChapterNo { get; set; }
    public decimal ChapterDuration { get; set; }
    public string ClassDetail { get; set; }
    public string IsClassOrExam { get; set; }
    public string BaseUrl { get; set; }
    public decimal ClassDuration { get; set; }

    #region Course Details
    public int CourseAssignId { get; set; }
    public int HostConfigId { get; set; }
    #endregion
}
