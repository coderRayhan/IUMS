using AspNetCoreHero.Abstractions.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUMS.Domain.Entities.LMS
{
    [Table("LMS_QuestionOptions")]
	public class QuestionOption : AuditableEntity
	{
		public int CourseQuestionId { get; set; }
		public string Option { get; set; }
		public bool IsAnswer { get; set; }
        public virtual CourseQuestion CourseQuestion { get; set; }
    }
}
