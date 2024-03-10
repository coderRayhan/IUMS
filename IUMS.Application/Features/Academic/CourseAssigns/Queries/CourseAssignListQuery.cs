using AspNetCoreHero.Results;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Academic.CourseAssigns.Queries;
public sealed record CourseAssignListQuery(
	int SessionId,
	int FacultyId,
	int DepartmentId,
	int ProgramId,
	int BatchId,
	int AcademicSemesterId)
    : IRequest<Result<IEnumerable<CourseAssignResponse>>>;

internal sealed record CourseAssignListQueryHandler(IDapperContext _dapper)
    : IRequestHandler<CourseAssignListQuery, Result<IEnumerable<CourseAssignResponse>>>
{
    public async Task<Result<IEnumerable<CourseAssignResponse>>> Handle(CourseAssignListQuery request, CancellationToken cancellationToken)
    {
		try
		{
			var sql = "";

			using var connection = _dapper.CreateConnection();

			var courseAssignList = await connection.QueryAsync<CourseAssignResponse>(sql, new { request.SessionId, request.FacultyId, request.DepartmentId, request.ProgramId, request.BatchId, request.AcademicSemesterId });

			return Result<IEnumerable<CourseAssignResponse>>.Success(courseAssignList);
		}
		catch (Exception ex)
		{
			return Result<IEnumerable<CourseAssignResponse>>.Fail(ex.Message);
		}
    }
}
