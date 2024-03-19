using AspNetCoreHero.Abstractions.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUMS.Domain.Entities.LMS
{
    [Table("LMS_ExamQuestions")]
	public class ExamQuestion : AuditableEntity
	{
		public int CourseExamId { get; set; }
		public int CourseQuestionId { get; set; }
		public bool IsRequired { get; set; }
		public bool IsSelected { get; set; }
        public virtual CourseExam CourseExam { get; set; }
    }
}
