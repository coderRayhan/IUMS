using AspNetCoreHero.Abstractions.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUMS.Domain.Entities.LMS
{
    [Table("LMS_StudentEvaluationDetail")]
    public class StudentEvaluationDetail : AuditableEntity
    {
        public int QuestionId { get; set; }
        public string Answer { get; set; }
        public string MCQAnswer { get; set; }
    }
}
