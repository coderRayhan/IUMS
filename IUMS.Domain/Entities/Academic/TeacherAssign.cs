using AspNetCoreHero.Abstractions.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUMS.Domain.Entities.Academic;
[Table("Aca_TeacherAssigns")]
public class TeacherAssign : AuditableEntity
{
    public int SessionId { get; set; }
    public int FacultyId { get; set; }
    public int DepartmentId { get; set; }
    public int ProgramId { get; set; }
    public int BatchId { get; set; }
    public int CourseId { get; set; }
    public int TeacherId { get; set; }
    public int AcademicSemesterId { get; set; }
}
