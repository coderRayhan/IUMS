using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using AutoMapper;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;

namespace IUMS.Application.Features.LMS.CourseExams.Queries
{
    public sealed record CourseExamListQuery(int CourseMasterId) : IRequest<Result<List<CourseExamResponse>>>;
	internal sealed record CourseExamListQueryHandler(
		IDapperContext _context,
		IMapper _mapper) 
		: IRequestHandler<CourseExamListQuery, Result<List<CourseExamResponse>>>
	{
		public async Task<Result<List<CourseExamResponse>>> Handle(CourseExamListQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var sql = "SELECT CE.Id, C.CourseCode, CM.Id CourseMasterId, C.CourseName, CE.Duration, CE.ExamTypeId, CE.IsActive, CAST(IIF(SE.IsEvaluated IS NOT NULL, 1, 0) AS bit) AS IsAnyStudentSubmit FROM LMS_CourseExams AS CE INNER JOIN LMS_CourseMasters AS CM ON CE.CourseMasterId = CM.Id INNER JOIN Aca_CourseAssign AS CA ON CM.CourseAssignId = CA.Id INNER JOIN Aca_Courses AS C ON CA.CourseId = C.Id LEFT JOIN LMS_StudentEvaluation SE ON SE.CourseMasterId = CE.CourseMasterId AND CE.Id = SE.ChapterExamId WHERE CE.CourseMasterId = @CourseMasterId";

				using var connection = _context.CreateConnection();

				var list = await connection.QueryAsync<CourseExamResponse>(sql, new { request.CourseMasterId });

				return Result<List<CourseExamResponse>>.Success(_mapper.Map<List<CourseExamResponse>>(list));
			}
			catch (Exception ex)
			{
				return Result<List<CourseExamResponse>>.Fail(ex.Message);
			}
		}
	}
}
