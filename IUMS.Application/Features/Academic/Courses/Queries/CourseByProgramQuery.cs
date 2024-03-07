using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;

namespace IUMS.Application.Features.Academic.Courses.Queries;
public sealed record CourseByProgramQuery(
    int ProgramId)
    : IRequest<Result<IEnumerable<CourseByProgramResponse>>>;
public record GetCourseByProgramQueryHandler(
    IDapperContext _context) 
    : IRequestHandler<CourseByProgramQuery, Result<IEnumerable<CourseByProgramResponse>>>
{
    public async Task<Result<IEnumerable<CourseByProgramResponse>>> Handle(CourseByProgramQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var sql = "SELECT Id, CONCAT(CourseCode, ' - ', CourseName) CourseName FROM Aca_Courses WHERE ProgramId = @ProgramId";

            using var connection = _context.CreateConnection();

            var list = await connection.QueryAsync<CourseByProgramResponse>(sql,new { request.ProgramId });
            return Result<IEnumerable<CourseByProgramResponse>>.Success(list);
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<CourseByProgramResponse>>.Fail(ex.Message);
        }
    }
}

