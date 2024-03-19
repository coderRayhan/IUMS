using AspNetCoreHero.Abstractions.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUMS.Domain.Entities.LMS;
[Table("LMS_CourseOutcomes")]
public class CourseOutcome : AuditableEntity
{
    public int CourseMasterId { get; set; }
    public string Outcome { get; set; }
    public int Serial { get; set; }
    public virtual CourseMaster CourseMaster { get; set; }
}
