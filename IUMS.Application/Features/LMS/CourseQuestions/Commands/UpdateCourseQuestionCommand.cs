using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using AutoMapper;
using IUMS.Application.Features.LMS.CourseQuestions.Queries;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.LMS;
using IUMS.Domain.Entities.LMS;
using MediatR;

namespace IUMS.Application.Features.LMS.CourseQuestions.Commands
{
    public sealed record UpdateCourseQuestionCommand : IRequest<Result<int>>
	{
		public int Id { get; set; }
		public int CourseMasterId { get; set; }
		public int? CourseChapterId { get; set; }
		public int QuestionTypeId { get; set; }
		public bool IsWritten { get; set; }
		public string Question { get; set; }
		public decimal Mark { get; set; }
		public string Answer { get; set; }
		public bool IsChaperQuestion { get; set; }
		public List<QuestionOptionResponse> QuestionOptions { get; set; }
	}
	internal sealed record UpdateCourseQuestionCommandHandler(ICourseQuestionRepository Repository, IMapper Mapper, IUnitOfWork UnitOfWork) : IRequestHandler<UpdateCourseQuestionCommand, Result<int>>
	{
		public async Task<Result<int>> Handle(UpdateCourseQuestionCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var entity = await Repository.GetByIdAsync(request.Id);
				if(entity == null)
				{
					return Result<int>.Fail("Data not found");
				}
				else
				{
					entity.CourseMasterId = request.CourseMasterId == 0 ? entity.CourseMasterId : request.CourseMasterId;
					entity.CourseChapterId = request.CourseChapterId == 0 ? entity.CourseChapterId : request.CourseChapterId;
					entity.QuestionTypeId = request.QuestionTypeId;
					entity.Question = request.Question;
					entity.Answer = request.Answer ?? entity.Answer;
					entity.Mark = request.Mark;
					entity.IsWritten = request.IsWritten;
					entity.QuestionOptions = Mapper.Map<List<QuestionOption>>(request.QuestionOptions);
					await Repository.UpdateAsync(entity);
					await UnitOfWork.Commit(cancellationToken);
					return Result<int>.Success(request.Id);
				}
			}
			catch (Exception ex)
			{
				return Result<int>.Fail(ex.Message);
			}
		}
	}
}
