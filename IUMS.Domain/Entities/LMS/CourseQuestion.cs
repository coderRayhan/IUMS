using AspNetCoreHero.Abstractions.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUMS.Domain.Entities.LMS
{
    [Table("LMS_CourseQuestions")]
	public class CourseQuestion : AuditableEntity
	{
		public int CourseMasterId { get; set; }
		public int? CourseChapterId { get; set; }
		public int QuestionTypeId { get; set; }
		public bool IsWritten { get; set; }
		public string Question { get; set; }
		public decimal Mark { get; set; }
		public string Answer { get; set; }
		public bool IsChaperQuestion { get; set; }
		public List<QuestionOption> QuestionOptions { get; set; }
        public virtual CourseMaster CourseMaster { get; set; }
    }
}
