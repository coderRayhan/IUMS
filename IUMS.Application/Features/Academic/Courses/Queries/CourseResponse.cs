namespace IUMS.Application.Features.Academic.Courses.Queries;
public class CourseResponse
{
    public int Id { get; set; }
    public string CourseName { get; set; }
    public string CourseNameBN { get; set; }
    public string CourseCode { get; set; }
    public int CourseTypeId { get; set; }
    public bool IsActive { get; set; }
    public int CreditHour { get; set; }
    public int ConductHour { get; set; }
    public int TotalClass { get; set; }
    public int ProgramId { get; set; }
    public string ProgramName { get; set; }
    public string ProgramNameBN { get; set; }
    public int SessionId { get; set; }
    public string SessionName { get; set; }
    public string SessionNameBN { get; set; }
    public int FacultyId { get; set; }
    public string FacultyName { get; set; }
    public string FacultyNameBN { get; set; }
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public string DepartmentNameBN { get; set; }
}

public class CourseByProgramResponse
{
    public int Id { get; set; }
    public string CourseName { get; set; }
}

