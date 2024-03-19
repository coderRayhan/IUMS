using AspNetCoreHero.Abstractions.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUMS.Domain.Entities.LMS;
[Table("LMS_CourseChapters")]
public class CourseChapter : AuditableEntity
{
    public int CourseMasterId { get; set; }
    public int ChapterNo { get; set; }
    [StringLength(200)]
    public string Title { get; set; }
    public decimal Duration { get; set; }
    public string Description { get; set; }
    public List<ChapterClass> ChapterClasses { get; set; }
    public virtual CourseMaster CourseMaster { get; set; }
}

