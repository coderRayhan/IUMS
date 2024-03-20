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
    public record UpdateCourseExamCommand(
		int Id, 
		int CourseMasterId, 
		int CourseChapterId, 
		int ChapterClassId, 
		int FollowedByChapterId, 
		int ExamNameId, 
		int ExamTypeId, 
		int NoOfQuestions,
		int QuesToBeAnswered, 
		decimal TotalMarks, 
		decimal PassMark,
		decimal Duration, 
		DateTime StartDate, 
		TimeSpan StartTime, 
		DateTime EndDate, 
		TimeSpan EndTime, 
		string AssignmentDetails, 
		string AssignmentUrl, 
		IList<ExamQuestionResponse> ExamQuestions) 
		: IRequest<Result<int>> { }
	public record UpdateCourseExamCommandHandler(ICourseExamRepository _repository, IMapper _mapper, IUnitOfWork _unitOfWork) : IRequestHandler<UpdateCourseExamCommand, Result<int>>
	{
		public async Task<Result<int>> Handle(UpdateCourseExamCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await _repository.GetByIdAsync(request.Id);
				if(data == null)
					return Result<int>.Fail("Data not found");
				data.CourseMasterId = request.CourseMasterId == 0 ? data.CourseMasterId : request.CourseMasterId;
				data.CourseChapterId = request.CourseChapterId == 0 ? data.CourseChapterId : request.CourseChapterId;
				data.ChapterClassId = request.ChapterClassId == 0 ? data.ChapterClassId : request.ChapterClassId;
				data.ExamTypeId = request.ExamTypeId;
				data.ExamNameId = request.ExamNameId;
				data.NoOfQuestions = request.NoOfQuestions;
				data.QuesToBeAnswered = request.QuesToBeAnswered;
				data.TotalMarks = request.TotalMarks;
				data.PassMark = request.PassMark;
				data.Duration = request.Duration;
				data.StartDate = request.StartDate;
				data.StartTime = request.StartTime;
				data.EndDate = request.EndDate;
				data.EndTime = request.EndTime;
				data.AssignmentDetails = request.AssignmentDetails;
				data.AssignmentUrl = request.AssignmentUrl;
				data.ExamQuestions = _mapper.Map<List<ExamQuestion>>(request.ExamQuestions);
				await _repository.UpdateAsync(data);
				await _unitOfWork.Commit(cancellationToken);
				return Result<int>.Success();
			}
			catch (Exception ex)
			{
				return Result<int>.Fail(ex.Message);
			}
		}
	}
}
