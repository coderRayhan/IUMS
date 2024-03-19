using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AspNetCoreHero.Abstractions.Domain;
using IUMS.Domain.Enums;

namespace IUMS.Domain.Entities.LMS;
[Table("LMS_ChapterClasses")]
public class ChapterClass : AuditableEntity
{
    public int CourseChapterId { get; set; }
    public string Title { get; set; }
    public decimal Duration { get; set; }
    public LMSClassType ClassTypeId { get; set; }
    public LMSFileType FileTypeId { get; set; }
    public DateTime StartDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public DateTime EndDate { get; set; }
    public TimeSpan EndTime { get; set; }
    [StringLength(200)]
    public string ContentUrl { get; set; }
    public string IsClassOrExam { get; set; }
    public int HostConfigId { get; set; }

    public string MeetingId { get; set; }
    public string Join_url { get; set; }
    public string Start_url { get; set; }
    public virtual CourseChapter CourseChapter { get; set; }
}
