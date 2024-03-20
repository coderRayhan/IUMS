using System;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;

namespace IUMS.Application.Features.LMS.CourseMasters.Queries
{
    public sealed record CourseAssignDataByChapterIdQuery(int ChapterId) : IRequest<Result<CommonProperties>> { }
	internal sealed record CourseAssignDataByChapterIdQueryHandler(
		IDapperContext _dapper) 
		: IRequestHandler<CourseAssignDataByChapterIdQuery, Result<CommonProperties>>
	{
		public async Task<Result<CommonProperties>> Handle(CourseAssignDataByChapterIdQuery request, CancellationToken cancellationToken)
		{
			try
			{
                var sql = "SELECT CA.AdmissionYearId, CA.FacultyId, CA.DepartmentId, CA.ProgramId, CA.BatchId, CA.SemesterId, CA.CourseId , Chapter.CourseMasterId FROM LMS_CourseChapters AS Chapter INNER JOIN LMS_CourseMasters AS [Master] ON Chapter.CourseMasterId = Master.Id INNER JOIN Aca_CourseAssigns AS CA ON [Master].CourseAssignId = CA.Id WHERE Chapter.Id = @ChapterId";

                using var connection = _dapper.CreateConnection();

                var data = await connection.QueryFirstAsync<CommonProperties>(sql, new { request.ChapterId });

				return Result<CommonProperties>.Success(data);
			}
			catch (Exception ex)
			{
				return Result<CommonProperties>.Fail(ex.Message);
			}
		}
	}
}
