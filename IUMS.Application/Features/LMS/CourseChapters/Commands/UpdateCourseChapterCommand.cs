using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using AutoMapper;
using IUMS.Application.Features.LMS.ChapterClasses.Queries;
using IUMS.Application.Features.LMS.CourseChapters.Queries;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.LMS;
using MediatR;

namespace IUMS.Application.Features.LMS.CourseChapters.Commands
{
    public sealed record UpdateCourseChapterCommand(
		int Id, 
		int CourseMasterId, 
		int ChapterNo, 
		string Title, 
		decimal Duration, 
		string Description, 
		List<ChapterClassResponse> ChapterClasses) 
		: IRequest<Result<CourseChapterResponse>> 
	{
	}
	internal sealed record UpdateCourseChapterCommandHandler(
		ICourseChapterRepository _repository, 
		IMapper _mapper, 
		IUnitOfWork _unitOfWork) : IRequestHandler<UpdateCourseChapterCommand, Result<CourseChapterResponse>>
	{
		public async Task<Result<CourseChapterResponse>> Handle(UpdateCourseChapterCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var entity = await _repository.GetByIdAsync(request.Id);
				if (entity == null)
				{
					return Result<CourseChapterResponse>.Fail("Data not found");
				}
				var CourseCharters = await _repository.GetListAsync();
				if (CourseCharters.Any(cc => cc.ChapterNo == request.ChapterNo && request.ChapterNo != entity.ChapterNo))
				{
                    return Result<CourseChapterResponse>.Fail("Chapter No Already Exist");
                }
				if (CourseCharters.Any(cc => cc.Title.ToUpper().Trim() == request.Title.ToUpper().Trim() && request.Title.ToUpper().Trim() != entity.Title.ToUpper().Trim()))
				{
                    return Result<CourseChapterResponse>.Fail("Same Title Already Exist");
                }
				else
				{
                    entity.CourseMasterId = request.CourseMasterId == 0 ? entity.CourseMasterId : request.CourseMasterId;
                    entity.ChapterNo = request.ChapterNo;
                    entity.Title = request.Title;
                    entity.Description = request.Description;
                    entity.Duration = request.Duration;
                    await _repository.UpdateAsync(entity);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<CourseChapterResponse>.Success();
                }

			}
			catch (Exception ex)
			{
				return Result<CourseChapterResponse>.Fail(ex.Message);
			}
		}
	}
}
