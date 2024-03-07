using AspNetCoreHero.Abstractions.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUMS.Domain.Entities.Academic;
[Table("Aca_Courses")]
public class Course : AuditableEntity
{
    public int ProgramId { get; set; }

    [StringLength(30)]
    public string CourseCode { get; set; }
    public decimal CreditHour { get; set; }
    public decimal ConductHour { get; set; }
    [StringLength(200)]
    public string CourseName { get; set; }
    public int CourseTypeId { get; set; }
    public int TotalClass { get; set; }
    public bool IsActive { get; set; }
    public virtual Program Program { get; set; }
}
