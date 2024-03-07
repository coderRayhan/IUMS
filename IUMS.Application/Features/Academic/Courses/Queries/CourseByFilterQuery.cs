using AspNetCoreHero.Boilerplate.Application.Interfaces.Shared;
using AspNetCoreHero.Results;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Academic.Courses.Queries;
public sealed record CourseByFilterQuery(
    int ProgramId) 
    : IRequest<Result<IEnumerable<CourseResponse>>>;

internal sealed record GetCourseByFilterQueryHandler(
    IDapperContext _dapper,
    IAuthenticatedUserService _userService) : IRequestHandler<CourseByFilterQuery, Result<IEnumerable<CourseResponse>>>
{
    public async Task<Result<IEnumerable<CourseResponse>>> Handle(CourseByFilterQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var sql = "SELECT C.Id, C.ProgramId, F.FacultyName, F.FacultyNameBN, C.TotalClass, D.DepartmentName, D.DepartmentNameBN,  P.ProgramName, P.ProgramNameBN, C.CourseCode, C.CourseName, C.CreditHour, C.ConductHour,  C.CourseTypeId, c.IsActive FROM dbo.Aca_Courses C INNER JOIN dbo.Aca_Programs P on C.ProgramId = p.Id  INNER JOIN dbo.Aca_Departments D ON D.Id = P.DepartmentId INNER JOIN dbo.Aca_Faculties  F ON F.Id = D.FacultyId  WHERE (0 = @ProgramId OR C.ProgramId = @ProgramId)";

            using var connection = _dapper.CreateConnection();

            var courseList = await connection.QueryAsync<CourseResponse>(sql, new { request.ProgramId });
            return Result<IEnumerable<CourseResponse>>.Success(courseList);
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<CourseResponse>>.Fail(ex.Message);
        }

    }
}

