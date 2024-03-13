using AspNetCoreHero.Abstractions.Domain;
using IUMS.Domain.Entities.Academic;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUMS.Domain.Entities.Employees;
[Table("Emp_Employees")]
public class Employee : AuditableEntity
{
    public int FacultyId { get; set; }
    public int DepartmentId { get; set; }
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
    public int GenderId { get; set; }
    public int ReligionId { get; set; }
    public virtual Faculty Faculty { get; set; }
    public virtual Department Department { get; set; }
}
