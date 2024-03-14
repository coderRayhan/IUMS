using AspNetCoreHero.Results;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Employees.Queries;
public sealed record EmployeeListQuery(
    int FacultyId,
    int DepartmentId,
    int GenderId)
    : IRequest<Result<IEnumerable<EmployeeResponse>>>;

internal sealed record EmployeeListQueryHandler(
    IDapperContext _dapper)
    : IRequestHandler<EmployeeListQuery, Result<IEnumerable<EmployeeResponse>>>
{
    public async Task<Result<IEnumerable<EmployeeResponse>>> Handle(EmployeeListQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var sql = "SELECT EMP.Id, EMP.FacultyId, EMP.DepartmentId, EMP.EmpId, EMP.FullName, EMP.FullNameBN, EMP.Email, EMP.PhoneNumber, EMP.Status, F.FacultyName, F.FacultyNameBN, D.DepartmentName, D.DepartmentNameBN, G.Name GenderName, G.NameBN GenderNameBN, BG.Name BloogGroup, BG.NameBN BloodGroupBN, N.Name NationalityName, N.NameBN NationalityNameBN FROM Emp_Employees EMP INNER JOIN Aca_Faculties F ON EMP.FacultyId = F.Id INNER JOIN Aca_Departments D ON EMP.DepartmentId = D.Id INNER JOIN Com_LookupDetails G ON EMP.GenderId = G.Id INNER JOIN Com_LookupDetails BG ON EMP.BloodGroupId = BG.Id INNER JOIN Com_LookupDetails N ON EMP.NationalityId = N.Id WHERE (0 = @FacultyId OR EMP.FacultyId = @FacultyId) AND (0 = @DepartmentId OR EMP.DepartmentId = @DepartmentId) AND (0 = @GenderId OR EMP.GenderId = @GenderId)";

            using var connection = _dapper.CreateConnection();

            var employeeList = await connection.QueryAsync<EmployeeResponse>(sql, new { request.FacultyId, request.DepartmentId, request.GenderId });

            return Result<IEnumerable<EmployeeResponse>>.Success(employeeList);
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<EmployeeResponse>>.Fail(ex.Message);
        }
    }
}
