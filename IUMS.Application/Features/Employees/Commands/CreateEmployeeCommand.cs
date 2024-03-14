using AspNetCoreHero.Results;
using AutoMapper;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Employees;
using IUMS.Domain.Entities.Employees;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Employees.Commands;
public sealed record CreateEmployeeCommand 
    : IRequest<Result<int>>
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
    public bool Status { get; set; } = true;
    public int NationalityId { get; set; }
    public int GenderId { get; set; }
    public int ReligionId { get; set; }
    public int BloodGroupId { get; set; }
    public string EmployeePhotoUrl { get; set; }
}

internal sealed record CreateEmployeeCommandHandler(
    IEmployeeRepository _repository,
    IMapper _mapper,
    IUnitOfWork _unitOfWork)
    : IRequestHandler<CreateEmployeeCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var employee = _mapper.Map<Employee>(request);

            await _repository.InsertAsync(employee);

            await _unitOfWork.Commit(cancellationToken);

            return Result<int>.Success(employee.Id);
        }
        catch (Exception ex)
        {
            return Result<int>.Fail(ex.Message);
        }
    }
}
