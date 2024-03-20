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
    public record ChapterQuestionByCourseMasterIdQuery(int CourseMasterId) : IRequest<Result<List<ExamQuestionResponse>>>;
	public record ChapterQuestionByCourseMasterIdQueryHandler(
		IDapperContext _dapper,
		IMapper _mapper) : IRequestHandler<ChapterQuestionByCourseMasterIdQuery, Result<List<ExamQuestionResponse>>>
	{
		public async Task<Result<List<ExamQuestionResponse>>> Handle(ChapterQuestionByCourseMasterIdQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var sql = "SELECT Id CourseQuestionId, CourseMasterId, CourseChapterId, QuestionTypeId, Question, QuestionTypeId QuestionType, Mark FROM LMS_CourseQuestions WHERE CourseMasterId = @CourseMasterId";

				using var connection = _dapper.CreateConnection();

				var list = await connection.QueryAsync<ExamQuestionResponse>(sql, new { request.CourseMasterId });

				return Result<List<ExamQuestionResponse>>.Success(_mapper.Map<List<ExamQuestionResponse>>(list));
			}
			catch (Exception ex)
			{
				return Result<List<ExamQuestionResponse>>.Fail(ex.Message);
			}
		}
	}
}
