using AspNetCoreHero.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUMS.Domain.Entities.LMS;
[Table("LMS_CourseFAQs")]
public class CourseFAQ : AuditableEntity
{
    public int CourseMasterId { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
    public virtual CourseMaster CourseMaster { get; set; }
}
