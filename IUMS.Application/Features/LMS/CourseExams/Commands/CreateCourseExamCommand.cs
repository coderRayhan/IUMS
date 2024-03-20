using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using AutoMapper;
using IUMS.Application.Features.LMS.ExamQuestions.Queries;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.LMS;
using IUMS.Domain.Entities.LMS;
using MediatR;

namespace IUMS.Application.Features.LMS.CourseExams.Commands
{
    public sealed record CreateCourseExamCommand : IRequest<Result<int>>
	{
		public int CourseMasterId { get; set; }
		public int CourseChapterId { get; set; }
		public int ChapterClassId { get; set; }
		public int FollowedByChapterId { get; set; }
		public int ExamNameId { get; set; }
		public int ExamTypeId { get; set; }
		public int PartId { get; set; }
		public int NoOfQuestions { get; set; }
		public int QuesToBeAnswered { get; set; }
		public decimal TotalMarks { get; set; }
		public decimal PassMark { get; set; }
		public decimal Duration { get; set; }
		public DateTime StartDate { get; set; }
		public TimeSpan StartTime { get; set; }
		public DateTime EndDate { get; set; }
		public TimeSpan EndTime { get; set; }
		public bool IsActive { get; set; }
		public string AssignmentDetails { get; set; }
		public string AssignmentUrl { get; set; }
		public IList<ExamQuestionResponse> ExamQuestions { get; set; }
	}
	internal sealed record CreateCourseExamCommandHandler(ICourseExamRepository _repository, IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<CreateCourseExamCommand, Result<int>>
	{
		public async Task<Result<int>> Handle(CreateCourseExamCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var mappedEntity = _mapper.Map<CourseExam>(request);
				await _repository.InsertAsync(mappedEntity);
				await _unitOfWork.Commit(cancellationToken);
				return Result<int>.Success(0);
			}
			catch (Exception ex)
			{
				return Result<int>.Fail(ex.Message);
			}
		}
	}
}
