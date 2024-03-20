using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using AutoMapper;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;

namespace IUMS.Application.Features.LMS.ExamQuestions.Queries
{
    public record ExamQuestionByCourseExamIdQuery(int CourseMasterId, int CourseExamId = 0) : IRequest<Result<List<ExamQuestionResponse>>> { }
	public record ExamQuestionByCourseExamIdQueryHandler(
		IDapperContext _dapper,
		IMapper _mapper) : IRequestHandler<ExamQuestionByCourseExamIdQuery, Result<List<ExamQuestionResponse>>>
	{
		public async Task<Result<List<ExamQuestionResponse>>> Handle(ExamQuestionByCourseExamIdQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var sql = "SELECT DISTINCT ISNULL(EQ.Id, 0) Id, ISNULL(EQ.CourseExamId, 0) CourseExamId, CQ.Id CourseQuestionId, ISNULL(EQ.IsRequired, 0) IsRequired, ISNULL(EQ.IsSelected, 0) IsSelected, CQ.CourseMasterId, CQ.CourseChapterId, CQ.QuestionTypeId , CQ.IsWritten, CQ.Question, CQ.Mark FROM LMS_CourseQuestions AS CQ LEFT JOIN LMS_ExamQuestions AS EQ ON EQ.CourseQuestionId = CQ.Id WHERE CQ.CourseMasterId = @CourseMasterId AND (0 = @CourseExamId OR EQ.CourseExamId = @CourseExamId)";

				using var connection = _dapper.CreateConnection();

				var list = await connection.QueryAsync<ExamQuestionResponse>(sql, new {request.CourseMasterId, request.CourseExamId});

				return Result<List<ExamQuestionResponse>>.Success(_mapper.Map<List<ExamQuestionResponse>>(list));
			}
			catch (Exception ex)
			{
				return Result<List<ExamQuestionResponse>>.Fail(ex.Message);
			}
		}
	}
}
