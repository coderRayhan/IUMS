using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using AutoMapper;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;

namespace IUMS.Application.Features.LMS.CourseQuestions.Queries
{
    public sealed record QuestionsByCourseMasterIdQuery(int CourseMasterId) : IRequest<Result<List<CourseQuestionResponse>>>;
	public record QuestionsByCourseMasterIdQueryHandler(
		IDapperContext _dapper,
		IMapper _mapper) : IRequestHandler<QuestionsByCourseMasterIdQuery, Result<List<CourseQuestionResponse>>>
	{
		public async Task<Result<List<CourseQuestionResponse>>> Handle(QuestionsByCourseMasterIdQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var sql = "SELECT Id CourseQuestionId, CourseMasterId, CourseChapterId, QuestionTypeId, Question, QuestionTypeId QuestionType, Mark FROM LMS_CourseQuestions WHERE CourseMasterId = @CourseMasterId";

				using var connection = _dapper.CreateConnection();

				var list = await connection.QueryAsync<CourseQuestionResponse>(sql, new { request.CourseMasterId });
				
				return Result<List<CourseQuestionResponse>>.Success(_mapper.Map<List<CourseQuestionResponse>>(list));
			}
			catch (Exception ex)
			{
				return Result<List<CourseQuestionResponse>>.Fail(ex.Message);
			}
		}
	}
}
