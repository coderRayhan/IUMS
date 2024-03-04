using AspNetCoreHero.Abstractions.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUMS.Domain.Entities.Student;
[Table("Std_StudentEducationalInfos")]
public class StudentEducationalInfo : AuditableEntity
{

    public int StudentBasicInfoId { get; set; }
    public int ExamId { get; set; }
    public int PassingYear { get; set; }
    public string InstitutionName { get; set; }
    public long RollNumber { get; set; }
    public int BoardId { get; set; }
    //public string BoardOrUniversity { get; set; }
    public decimal ExamResult { get; set; }
}
