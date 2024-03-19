using AspNetCoreHero.Abstractions.Domain;
using IUMS.Domain.Entities.Academic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUMS.Domain.Entities.LMS
{
    [Table("LMS_CourseMasters")]
    public class CourseMaster : AuditableEntity
    {
        public int CourseAssignId { get; set; }
        public int TeacherId { get; set; }
        public string CourseObjective { get; set; }
        public string CourseOutline { get; set; }
        [StringLength(200)]
        public string VideoUrl { get; set; }
        [StringLength(200)]
        public string ThumbnailUrl { get; set; }
        [StringLength(200)]
        public string TextBook { get; set; }
        [StringLength(200)]
        public string ReferenceBook { get; set; }
        public List<CourseChapter> CourseChapters { get; set; }
        public List<CourseOutcome> CourseOutcomes { get; set; }
        public List<CourseFAQ> CourseFAQs { get; set; }
        public virtual CourseAssign CourseAssign { get; set; }
    }
}
