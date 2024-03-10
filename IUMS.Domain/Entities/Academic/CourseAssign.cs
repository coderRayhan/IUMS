using AspNetCoreHero.Abstractions.Domain;

namespace IUMS.Domain.Entities.Academic;
public class CourseAssign : AuditableEntity
{
    public int SessionId { get; set; }
    public int FacultyId { get; set; }
    public int DepartmentId { get; set; }
    public int ProgramId { get; set; }
    //public int SemesterId { get; set; }
    public int AcademicSemesterId { get; set; }
    public int CourseId { get; set; }
    public double TotalMarks { get; set; }
    public decimal ContinuousAssesment { get; set; }
    public decimal TermFinal { get; set; }
    public decimal PassMark { get; set; }
    public int BatchId { get; set; }
    public virtual Session Session { get; set; }
    public virtual Faculty Faculty { get; set; }
    public virtual Department Department { get; set; }
    public virtual Program Program { get; set; }
    public virtual Batch Batch { get; set; }

}
