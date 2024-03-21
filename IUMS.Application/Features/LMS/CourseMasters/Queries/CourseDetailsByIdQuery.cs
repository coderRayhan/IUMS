using System;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using Dapper;
using IUMS.Application.Features.Academic.Courses.Queries;
using IUMS.Application.Interfaces.Contexts;
using MediatR;

namespace IUMS.Application.Features.LMS.CourseMasters.Queries
{
    public record CourseDetailsByIdQuery(int Id) : IRequest<Result<CourseResponse>>
	{
	}
	public record CourseDetailsByIdQueryHandler(
		IDapperContext _dapper) 
		: IRequestHandler<CourseDetailsByIdQuery, Result<CourseResponse>>
	{
		public async Task<Result<CourseResponse>> Handle(CourseDetailsByIdQuery request, CancellationToken cancellationToken)
		{
			try
			{
                var sql = "SELECT C.Id, S.SessionName, S.SessionNameBN, F.FacultyName, F.FacultyNameBN, D.DepartmentName, D.DepartmentNameBN, P.ProgramName, P.ProgramNameBN, C.CourseCode, C.CourseName, C.CreditHour, C.ConductHour, C.TotalClass FROM Aca_CourseAssigns AS CA INNER JOIN Aca_Sessions AS S ON CA.SessionId = S.Id INNER JOIN Aca_Faculties AS F ON CA.FacultyId = F.Id INNER JOIN Aca_Departments AS D ON CA.DepartmentId = D.Id INNER JOIN Aca_Programs AS P ON CA.ProgramId = P.Id INNER JOIN Aca_Courses AS C ON CA.CourseId = C.Id WHERE CA.Id = @Id";

                using var connection = _dapper.CreateConnection();

                var data = await connection.QueryFirstAsync<CourseResponse>(sql, new { request.Id });

				return Result<CourseResponse>.Success(data);
			}	
			catch (Exception ex)
			{
				return Result<CourseResponse>.Fail(ex.Message);
			}
		}
	}
}
