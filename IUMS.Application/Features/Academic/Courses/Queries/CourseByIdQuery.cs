using AspNetCoreHero.Results;
using AutoMapper;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using IUMS.Application.Interfaces.Repositories.Academic;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Academic.Courses.Queries;
public record CourseByIdQuery(
    int Id)
    : IRequest<Result<CourseResponse>>;
public record GetCourseByIdQueryHandler(
    IDapperContext _dapper,
    IMapper _mapper)
: IRequestHandler<CourseByIdQuery, Result<CourseResponse>>
{
    public async Task<Result<CourseResponse>> Handle(CourseByIdQuery query, CancellationToken cancellationToken)
    {
        try
        {
            var sql = "SELECT C.Id, C.ProgramId, C.CourseCode, C.CreditHour, C.ConductHour, C.CourseName, C.CourseTypeId, C.TotalClass, C.IsActive, D.Id DepartmentId, F.Id FacultyId FROM Aca_Courses C INNER JOIN Aca_Programs P ON C.ProgramId = P.Id INNER JOIN Aca_Departments D ON P.DepartmentId = D.Id INNER JOIN Aca_Faculties F ON D.FacultyId = F.Id WHERE C.Id = @Id";

            using var connection = _dapper.CreateConnection();

            var course = await connection.QueryFirstAsync<CourseResponse>(sql, new {query.Id});

            if (course == null)
                return Result<CourseResponse>.Fail("Course not found");

            return Result<CourseResponse>.Success(_mapper.Map<CourseResponse>(course));
        }
        catch (Exception ex)
        {
            return Result<CourseResponse>.Fail(ex.Message);
        }
    }
}
