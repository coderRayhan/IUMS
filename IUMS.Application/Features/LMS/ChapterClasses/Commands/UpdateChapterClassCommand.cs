using System;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using AutoMapper;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.LMS;
using IUMS.Domain.Enums;
using MediatR;

namespace IUMS.Application.Features.LMS.ChapterClasses.Commands
{
    public record UpdateChapterClassCommand(
		int Id, 
		int CourseChapterId, 
		string Title, 
		decimal Duration, 
		LMSClassType ClassTypeId, 
		LMSFileType FileTypeId, 
		DateTime StartDate, 
		TimeSpan StartTime, 
		DateTime EndDate, 
		TimeSpan EndTime, 
		string contentUrl, 
		string IsClassOrExam, 
		int HostConfigId) 
		: IRequest<Result<int>> { }
	public record UpdateChapterClassCommandHandler(IChapterClassRepository _repository, IMapper _mapper, IUnitOfWork _unitOfWork) : IRequestHandler<UpdateChapterClassCommand, Result<int>>
	{
		public async Task<Result<int>> Handle(UpdateChapterClassCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var entity = await _repository.GetByIdAsync(request.Id);
				if (entity is null)
					return Result<int>.Fail("Data not found");
				entity.CourseChapterId = request.CourseChapterId == 0 ? entity.CourseChapterId : request.CourseChapterId;
				entity.Title = request.Title ?? entity.Title;
				entity.Duration = request.Duration == 0 ? entity.Duration : request.Duration;
				entity.ClassTypeId = request.ClassTypeId == 0 ? entity.ClassTypeId : request.ClassTypeId;
				entity.FileTypeId = request.FileTypeId == 0 ? entity.FileTypeId : request.FileTypeId;
				entity.StartDate = request.StartDate;
				entity.StartTime = request.StartTime;
				entity.EndDate = request.EndDate;
				entity.EndTime = request.EndTime;
				entity.HostConfigId = request.HostConfigId == 0 ? entity.HostConfigId : request.HostConfigId;
				entity.IsClassOrExam = request.IsClassOrExam;
				entity.ContentUrl = request.contentUrl ?? entity.ContentUrl;
				await _repository.UpdateAsync(entity);
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
