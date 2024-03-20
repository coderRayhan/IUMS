using IUMS.Application.Features.LMS.CourseMasters.Queries;
using IUMS.Domain.Enums;
using System;

namespace IUMS.Application.Features.LMS.ChapterClasses.Queries;
public class ChapterClassResponse
{
    public int Id { get; set; }
    public int CourseChapterId { get; set; }
    public string CourseName { get; set; }
    public string CourseCode { get; set; }
    public int ChapterNo { get; set; }
    public string ChapterTitle { get; set; }
    public decimal ChapterDuration { get; set; }
    public string Title { get; set; }
    public decimal Duration { get; set; }
    public LMSClassType ClassTypeId { get; set; }
    public LMSFileType FileTypeId { get; set; }
    public DateTime StartDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public DateTime EndDate { get; set; }
    public TimeSpan EndTime { get; set; }
    public string ContentUrl { get; set; }
    public string IsClassOrExam { get; set; }
    public int HostConfigId { get; set; }
    public decimal ConductHour { get; set; }
    public decimal CreditHour { get; set; }
    public string TeacherName { get; set; }
    public string PartName { get; set; }

    // zoom meeting response
    public string MeetingId { get; set; } = string.Empty;
    public string Join_url { get; set; }
    public string Start_url { get; set; }
}

public class GetClassListWithChapterDetailsResponse : CommonProperties
{
    public string CourseObjective { get; set; }
    public string CourseOutline { get; set; }
    public int CourseChapterId { get; set; }
    public string ChapterTitle { get; set; }
    public decimal ChapterDuration { get; set; }
    public string ClassDetail { get; set; }
    public string IsClassOrExam { get; set; }
    public decimal ClassDuration { get; set; }
}
