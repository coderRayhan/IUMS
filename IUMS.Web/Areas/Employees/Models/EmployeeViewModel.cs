using System;

namespace IUMS.Web.Areas.Employees.Models;

public class EmployeeViewModel
{
    public int Id { get; set; }
    public int FacultyId { get; set; }
    public string FacultyName { get; set; }
    public string FacultyNameBN { get; set; }
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public string DepartmentNameBN { get; set; }
    public string EmpId { get; set; }
    public string TeacherShortCode { get; set; }
    public string FullName { get; set; }
    public string FullNameBN { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string NIDNo { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime? JoiningDate { get; set; }
    public bool Status { get; set; }
    public int NationalityId { get; set; }
    public string NationalityName { get; set; }
    public string NationalityNameBN { get; set; }
    public int GenderId { get; set; }
    public string GenderName { get; set; }
    public string GenderNameBN { get; set; }
    public int ReligionId { get; set; }
    public string ReligionName { get; set; }
    public string ReligionNameBN { get; set; }
    public int BloodGroupId { get; set; }
    public string BloodGroup { get; set; }
    public string BloodGroupBN { get; set; }
    public string EmployeePhotoUrl { get; set; }
}
