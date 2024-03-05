using AspNetCoreHero.Results;
using AutoMapper;
using IUMS.Application.Features.Student.StudentBasicInfos.Queries;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Student;
using IUMS.Domain.Entities.Student;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Student.StudentBasicInfos.Commands;
public sealed class CreateStudentBasicInfoCommand 
    : IRequest<Result<int>>
{
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
    public List<StudentEducationalInfoResponse> StudentEducationalInfos { get; set; } = new();
}

internal sealed record CreateStudentBasicInfoCommandHandler(
    IStudentBasicInfoRepository _repository,
    IMapper _mapper,
    IUnitOfWork _unitOfWork)
    : IRequestHandler<CreateStudentBasicInfoCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateStudentBasicInfoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            StudentBasicInfo studentBasicInfo = _mapper.Map<StudentBasicInfo>(request);

            await _repository.InsertAsync(studentBasicInfo);

            await _unitOfWork.Commit(cancellationToken);

            return Result<int>.Success(studentBasicInfo.Id);
        }
        catch (Exception ex)
        {
            return Result<int>.Fail(ex.Message);
        }
    }
}