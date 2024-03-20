using System;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;

namespace IUMS.Application.Features.LMS.CourseChapters.Queries
{
    public sealed record ChapterAndCourseDetailsByChapterIdQuery(int ChapterId) : IRequest<Result<ChapterAndCourseDetailsByChapterIdResponse>> { }
	internal sealed record GetChapterAndCourseDetailsByChapterIdQueryHandler(
		IDapperContext _dapper) 
		: IRequestHandler<ChapterAndCourseDetailsByChapterIdQuery, Result<ChapterAndCourseDetailsByChapterIdResponse>>
	{
		public async Task<Result<ChapterAndCourseDetailsByChapterIdResponse>> Handle(ChapterAndCourseDetailsByChapterIdQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var sql = "SELECT CC.Id CourseChapterId, CC.CourseMasterId, C.CourseCode, C.CourseName, C.CreditHour, C.ConductHour, Part.Name PartName, Emp.FullName TeacherName, CC.ChapterNo,CC.Title ChapterTitle, CC.Duration ChapterDuration, CM.CourseAssignId FROM LMS_CourseChapters CC INNER JOIN LMS_CourseMasters CM ON CC.CourseMasterId = CM.Id INNER JOIN Aca_CourseAssign CA ON CM.CourseAssignId = CA.Id INNER JOIN Aca_Courses C ON CA.CourseId = C.Id LEFT JOIN Emp_Employees Emp ON CM.TeacherId = Emp.Id LEFT JOIN Exm_LookupDetails AS Part ON CM.PartId = Part.Id WHERE CC.Id = @ChapterId";

				using var connection = _dapper.CreateConnection();

				var entity = await connection.QueryFirstAsync<ChapterAndCourseDetailsByChapterIdResponse>(sql, new { request.ChapterId });

				return Result<ChapterAndCourseDetailsByChapterIdResponse>.Success(entity);
			}
			catch (Exception ex)
			{
				return Result<ChapterAndCourseDetailsByChapterIdResponse>.Fail(ex.Message);
			}
		}
	}
}
