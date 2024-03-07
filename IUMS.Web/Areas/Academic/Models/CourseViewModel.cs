using System.ComponentModel.DataAnnotations;

namespace IUMS.Web.Areas.Academic.Models;

public class CourseViewModel
{
    public int Id { get; set; }
    public string CourseName { get; set; }
    public string CourseNameBN { get; set; }
    public string CourseCode { get; set; }
    public int CourseTypeId { get; set; }
    public bool IsActive { get; set; }
    public int TotalClass { get; set; }
    public decimal CreditHour { get; set; }
    public decimal ConductHour { get; set; }
    public int FacultyId { get; set; }
    public string FacultyName { get; set; }
    public string FacultyNameBN { get; set; }
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public string DepartmentNameBN { get; set; }
    public int ProgramId { get; set; }
    public string ProgramName { get; set; }
    public string ProgramNameBN { get; set; }
}
