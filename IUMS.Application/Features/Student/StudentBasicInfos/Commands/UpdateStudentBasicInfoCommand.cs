using AspNetCoreHero.Results;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Student;
using IUMS.Domain.Entities.Student;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Student.StudentBasicInfos.Commands;
public sealed record UpdateStudentBasicInfoCommand 
    : IRequest<Result<int>>
{
    public int Id { get; set; }
    public string ClassRollNo { get; set; }
    public int RegistrationNumber { get; set; }
    public DateTime DateOfAdmission { get; set; }
    public int SessionId { get; set; }
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
    public int BatchId { get; set; }         // Student Running BatchId
    public int SemesterId { get; set; }
    public string StudentImageUrl { get; set; }
    public int IsRegistered { get; set; }
    public int AdviserId { get; set; }
    public bool IsAdviserAssigned { get; set; }
    public bool IsActive { get; set; } = true;
    public int AcademicSemesterId { get; set; }
    public List<StudentEducationalInfo> StudentEducationalInfos { get; set; } = new();
}

internal sealed record UpdateStudentBasicInfoCommandHandler(
    IStudentBasicInfoRepository _repository,
    IUnitOfWork _unitOfWork)
    : IRequestHandler<UpdateStudentBasicInfoCommand, Result<int>>
{
    public async Task<Result<int>> Handle(UpdateStudentBasicInfoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            StudentBasicInfo studentBasicInfo = await _repository.GetByIdAsync(request.Id);

            if(studentBasicInfo == null) 
                return Result<int>.Fail("Data not found");

            studentBasicInfo.ClassRollNo = request.ClassRollNo;
            studentBasicInfo.RegistrationNumber = request.RegistrationNumber;
            studentBasicInfo.DateOfAdmission = request.DateOfAdmission;
            studentBasicInfo.SemesterId = request.SessionId;
            studentBasicInfo.StudentName = request.StudentName;
            studentBasicInfo.MobileNo = request.MobileNo;
            studentBasicInfo.Email = request.Email;
            studentBasicInfo.NID = request.NID;
            studentBasicInfo.FatherName = request.FatherName;
            studentBasicInfo.FatherMobileNo = request.FatherMobileNo;
            studentBasicInfo.MotherName = request.MotherName;
            studentBasicInfo.MotherMobileNo = request.MotherMobileNo;
            studentBasicInfo.DateOfBirth = request.DateOfBirth;
            studentBasicInfo.GenderId = request.GenderId;
            studentBasicInfo.ReligionId = request.ReligionId;
            studentBasicInfo.BloodGroupId = request.BloodGroupId;
            studentBasicInfo.VillageName = request.VillageName;
            studentBasicInfo.DistrictId = request.DistrictId;
            studentBasicInfo.UpazillaId = request.UpazillaId;
            studentBasicInfo.PostOffice = request.PostOffice;
            studentBasicInfo.FacultyId = request.FacultyId;
            studentBasicInfo.DepartmentId = request.DepartmentId;
            studentBasicInfo.ProgramId = request.ProgramId;
            studentBasicInfo.BatchId = request.BatchId;
            studentBasicInfo.SemesterId = request.SemesterId;
            studentBasicInfo.StudentImageUrl = request.StudentImageUrl;
            studentBasicInfo.AcademicSemesterId = request.AcademicSemesterId;
            studentBasicInfo.StudentEducationalInfos = request.StudentEducationalInfos;

            await _repository.UpdateAsync(studentBasicInfo);

            await _unitOfWork.Commit(cancellationToken);

            return Result<int>.Success(studentBasicInfo.Id);
        }
        catch (Exception ex)
        {
            return Result<int>.Fail(ex.Message);
        }
    }
}