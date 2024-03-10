namespace IUMS.Web.Areas.Academic.Models;

public class CourseAssignViewModel
{
    public int Id { get; set; }
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
}
