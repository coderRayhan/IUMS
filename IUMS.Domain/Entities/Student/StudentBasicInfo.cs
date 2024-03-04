using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using AspNetCoreHero.Abstractions.Domain;
using System.Collections.Generic;

namespace IUMS.Domain.Entities.Student;
[Table("Std_StudentBasicInfos")]
public class StudentBasicInfo : AuditableEntity
{
    [StringLength(200)]
    public string ClassRollNo { get; set; }
    //public int ApplicationId { get; set; }
    //[StringLength(200)]
    //public string ApplicationCode { get; set; }
    public int RegistrationNumber { get; set; }
    public DateTime DateOfAdmission { get; set; }
    public int SessionId { get; set; }
    [StringLength(200)]
    public string StudentName { get; set; }
    [StringLength(200)]
    public string MobileNo { get; set; }
    [StringLength(200)]
    public string Email { get; set; }
    [StringLength(200)]
    public string NID { get; set; }
    [StringLength(200)]
    public string FatherName { get; set; }
    [StringLength(200)]
    public string FatherMobileNo { get; set; }
    [StringLength(200)]
    public string MotherName { get; set; }
    [StringLength(200)]
    public string MotherMobileNo { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int GenderId { get; set; }
    public int ReligionId { get; set; }
    public int MaritalStatusId { get; set; }
    public int BloodGroupId { get; set; }
    [StringLength(200)]
    public string VillageName { get; set; }
    public int DistrictId { get; set; }
    public int UpazillaId { get; set; }
    [StringLength(200)]
    public string PostOffice { get; set; }
    [StringLength(200)]
    public int FacultyId { get; set; }
    public int DepartmentId { get; set; }
    public int ProgramId { get; set; }
    public int BatchId { get; set; }         // Student Running BatchId
    public int SemesterId { get; set; }
    public string StudentImageUrl { get; set; }
    //[NotMapped]
    //public IFormFile ApplicantImage { get; set; }
    public int IsRegistered { get; set; }
    [StringLength(30)]
    public int AdviserId { get; set; }
    public bool IsAdviserAssigned { get; set; }
    //public bool IsChecked { get; set; }
    //public int CheckedBy { get; set; }
    //public DateTime CheckedDate { get; set; }
    public bool IsActive { get; set; } = true;
    public int AcademicSemesterId { get; set; }
    public virtual List<StudentEducationalInfo> StudentEducationalInfos { get; set; }
}
