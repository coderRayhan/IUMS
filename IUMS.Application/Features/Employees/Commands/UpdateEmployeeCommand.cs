using AspNetCoreHero.Results;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Employees;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Employees.Commands;
public sealed record UpdateEmployeeCommand 
    : IRequest<Result<int>>
{
    public int Id { get; set; }
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
    public int BloodGroupId { get; set; }
    public string EmployeePhotoUrl { get; set; }
}

internal sealed record UpdateEmployeeCommandHandler(
    IEmployeeRepository _repository,
    IUnitOfWork _unitOfWork)
    : IRequestHandler<UpdateEmployeeCommand, Result<int>>
{
    public async Task<Result<int>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var employee = await _repository.GetByIdAsync(request.Id);

            if (employee is null)
                return Result<int>.Fail("Data not found");

            employee.FacultyId = request.FacultyId;
            employee.DepartmentId = request.DepartmentId;
            employee.EmpId = request.EmpId;
            employee.FullName = request.FullName;
            employee.FullNameBN = request.FullNameBN;
            employee.Email = request.Email;
            employee.PhoneNumber = request.PhoneNumber;
            employee.TeacherShortCode = request.TeacherShortCode;
            employee.NIDNo = request.NIDNo;
            employee.JoiningDate = request.JoiningDate;
            employee.DateOfBirth = request.DateOfBirth;
            employee.NationalityId = request.NationalityId;
            employee.GenderId = request.GenderId;
            employee.ReligionId = request.ReligionId;
            employee.BloodGroupId = request.BloodGroupId;
            employee.EmployeePhotoUrl = request.EmployeePhotoUrl;

            await _repository.UpdateAsync(employee);

            await _unitOfWork.Commit(cancellationToken);

            return Result<int>.Success(employee.Id);
        }
        catch (Exception ex)
        {
            return Result<int>.Fail(ex.Message);
        }
    }
}
