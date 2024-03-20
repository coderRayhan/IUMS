using System;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;

namespace IUMS.Application.Features.LMS.CourseMasters.Queries
{
    public sealed record CourseDetailsByCourseMasterIdQuery(int CourseMasterId) : IRequest<Result<CommonProperties>>;
	internal sealed record CourseDetailsByCourseMasterIdQueryHandler(
		IDapperContext _dapper) 
		: IRequestHandler<CourseDetailsByCourseMasterIdQuery, Result<CommonProperties>>
	{
		public async Task<Result<CommonProperties>> Handle(CourseDetailsByCourseMasterIdQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var sql = "SELECT CourseMasterId, AdmissionYearId, AdmissionYearName, AdmissionYearNameBN, FacultyId, FacultyName, FacultyNameBN, DepartmentId, DepartmentName, DepartmentNameBN, ProgramId, ProgramName, ProgramNameBN, BatchId, BatchName, BatchNameBN, SemesterId, SemesterName, SemesterNameBN, CourseId, CourseName, CourseCode, ConductHour, CreditHour FROM vwLMSCourseDetails WHERE CourseMasterId = @CourseMasterId";

				using var connection = _dapper.CreateConnection();

				var data = await connection.QueryFirstAsync<CommonProperties>(sql, new { request.CourseMasterId });

				return Result<CommonProperties>.Success(data);
			}
			catch (Exception ex)
			{
				return Result<CommonProperties>.Fail(ex.Message);
			}
		}
	}
}
