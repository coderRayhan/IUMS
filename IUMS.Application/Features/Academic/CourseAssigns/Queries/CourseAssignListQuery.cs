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
			var sql = "SELECT CA.Id, CA.CourseId, C.CourseName, CA.SessionId, S.SessionName, S.SessionNameBN, CA.FacultyId, F.FacultyName, F.FacultyNameBN, CA.DepartmentId, D.DepartmentName, D.DepartmentNameBN, CA.ProgramId, P.ProgramName, P.ProgramNameBN, CA.BatchId, B.BatchName, B.BatchNameBN, CA.AcademicSemesterId, CASE @AcademicSemesterId WHEN 1 THEN 'Spring' WHEN 2 THEN 'Summer' ELSE 'Fall' END AcademicSemesterName, CA.TotalMarks, CA.ContinuousAssesment, CA.TermFinal, CA.PassMark FROM Aca_CourseAssigns CA INNER JOIN Aca_Sessions S ON CA.SessionId = S.Id INNER JOIN Aca_Faculties F ON CA.FacultyId = F.Id INNER JOIN Aca_Departments D ON CA.DepartmentId = D.Id INNER JOIN Aca_Programs P ON CA.ProgramId = P.Id INNER JOIN Aca_Batches B ON CA.BatchId = B.Id INNER JOIN Aca_Courses C ON CA.CourseId = C.Id WHERE (0 = @SessionId OR CA.SessionId = @SessionId) AND (0 = @FacultyId OR CA.FacultyId = @FacultyId) AND (0 = @DepartmentId OR CA.DepartmentId = @DepartmentId) AND (0 = @ProgramId OR CA.ProgramId = @ProgramId) AND (0 = @BatchId OR BatchId = @BatchId) AND (0 = @AcademicSemesterId OR AcademicSemesterId = @AcademicSemesterId)";

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
