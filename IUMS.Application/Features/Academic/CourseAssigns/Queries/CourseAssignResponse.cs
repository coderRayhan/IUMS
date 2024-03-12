namespace IUMS.Application.Features.Academic.CourseAssigns.Queries;
public class CourseAssignResponse
{
    public int Id { get; set; }
    public int SessionId { get; set; }
    public string SessionName { get; set; }
    public string SessionNameBN { get; set; }
    public int FacultyId { get; set; }
    public string FacultyName { get; set; }
    public string FacultyNameBN { get; set; }
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public string DepartmentNameBN { get; set; }
    public int ProgramId { get; set; }
    public string ProgramName { get; set; }
    public string ProgramNameBN { get; set; }
    //public int SemesterId { get; set; }
    public int AcademicSemesterId { get; set; }
    public string AcademicSemesterName { get; set; }
    public string AcademicSemesterNameBN { get; set; }
    public int CourseId { get; set; }
    public string CourseName { get; set; }
    public double TotalMarks { get; set; }
    public decimal ContinuousAssesment { get; set; }
    public decimal TermFinal { get; set; }
    public decimal PassMark { get; set; }
    public int BatchId { get; set; }
    public string BatchName { get; set; }
    public string BatchNameBN { get; set; }
}
