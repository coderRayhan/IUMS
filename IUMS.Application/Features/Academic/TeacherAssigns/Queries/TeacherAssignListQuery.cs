using AspNetCoreHero.Results;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Academic.TeacherAssigns.Queries;
public sealed record TeacherAssignListQuery 
    : IRequest<Result<IEnumerable<TeacherAssignResponse>>>;

internal sealed record TeacherAssignListQueryHandler(
	IDapperContext _dapper)
    : IRequestHandler<TeacherAssignListQuery, Result<IEnumerable<TeacherAssignResponse>>>
{
    public async Task<Result<IEnumerable<TeacherAssignResponse>>> Handle(TeacherAssignListQuery request, CancellationToken cancellationToken)
    {
		try
		{
			var sql = "SELECT TA.Id, TA.SessionId, TA.FacultyId, TA.DepartmentId, TA.ProgramId, TA.BatchId, TA.AcademicSemesterId, TA.TeacherId, S.SessionName, S.SessionNameBN, F.FacultyName, F.FacultyNameBN, D.DepartmentName, D.DepartmentNameBN, P.ProgramName, P.ProgramNameBN, B.BatchName, B.BatchNameBN, C.CourseName, TA.CourseId,CASE TA.AcademicSemesterId WHEN 1 THEN 'Spring' WHEN 2 THEN 'Summer' ELSE 'Fall' END AcademicSemesterName, EMP.FullName TeacherName, EMP.FullNameBN TeacherNameBN FROM Aca_TeacherAssigns TA INNER JOIN Aca_Sessions S ON TA.SessionId = S.Id INNER JOIN Aca_Faculties F ON TA.FacultyId = F.Id INNER JOIN Aca_Departments D ON TA.DepartmentId = D.Id INNER JOIN Aca_Programs P ON TA.ProgramId = P.Id INNER JOIN Aca_Batches B ON TA.BatchId = B.Id INNER JOIN Aca_Courses C ON TA.CourseId = C.Id INNER JOIN Emp_Employees EMP ON TA.TeacherId = EMP.Id";
			
			using var connection = _dapper.CreateConnection();

			var list = await connection.QueryAsync<TeacherAssignResponse>(sql);

			return Result<IEnumerable<TeacherAssignResponse>>.Success(list);

		}
		catch (System.Exception ex)
		{
            return Result<IEnumerable<TeacherAssignResponse>>.Fail(ex.Message);

        }
    }
}
