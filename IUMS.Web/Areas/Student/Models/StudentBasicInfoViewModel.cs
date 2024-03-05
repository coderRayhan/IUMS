using IUMS.Domain.Entities.Student;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Http;

namespace IUMS.Web.Areas.Student.Models;

public class StudentBasicInfoViewModel
{
    public int Id { get; set; }
    public string ClassRollNo { get; set; }
    public int RegistrationNumber { get; set; }
    public DateTime DateOfAdmission { get; set; }
    public int SessionId { get; set; }
    public string SessionName { get; set; }
    public string SessionNameBN { get; set; }
    public string StudentName { get; set; }
    public string MobileNo { get; set; }
    public string Email { get; set; }
    public string NID { get; set; }
    public string FatherName { get; set; }
    public string FatherMobileNo { get; set; }
    public string MotherName { get; set; }
    public string MotherMobileNo { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int GenderId { get; set; }
    public int ReligionId { get; set; }
    public int BloodGroupId { get; set; }
    public string VillageName { get; set; }
    public int DistrictId { get; set; }
    public int UpazillaId { get; set; }
    public string PostOffice { get; set; }
    public int FacultyId { get; set; }
    public int DepartmentId { get; set; }
    public int ProgramId { get; set; }
    public string ProgramName { get; set; }
    public string ProgramNameBN { get; set; }
    public int BatchId { get; set; }         // Student Running BatchId
    public string BatchName { get; set; }
    public string BatchNameBN { get; set; }
    public int SemesterId { get; set; }
    public string SemesterName { get; set; }
    public string SemesterNameBN { get; set; }
    public string StudentImageUrl { get; set; }
    public IFormFile StudentImage { get; set; }
    public int IsRegistered { get; set; }
    public int AdviserId { get; set; }
    public bool IsAdviserAssigned { get; set; }
    public bool IsActive { get; set; } = true;
    public int AcademicSemesterId { get; set; }
    public string AcademicSemesterName { get; set; }
    public string AcademicSemesterNameBN { get; set; }
    public List<StudentEducationalInfoViewModel> StudentEducationalInfos { get; set; } = new();
}
