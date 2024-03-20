using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using AutoMapper;
using IUMS.Application.Features.LMS.CourseChapters.Queries;
using IUMS.Application.Features.LMS.CourseMasters.Queries;
using IUMS.Application.Features.LMS.CourseOutcomes.Queries;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.LMS;
using IUMS.Domain.Entities.LMS;
using MediatR;

namespace IUMS.Application.Features.LMS.CourseMasters.Commands
{
    public sealed record UpdateCourseMasterCommand : IRequest<Result<int>>
	{
		public int Id { get; set; }
		public int CourseAssignId { get; set; }
		public int PartId { get; set; }
		public int TeacherId { get; set; }
		[StringLength(500)]
		public string CourseObjective { get; set; }
		[StringLength(500)]
		public string CourseOutline { get; set; }
		[StringLength(200)]
		public string VideoUrl { get; set; }
		[StringLength(200)]
		public string ThumbnailUrl { get; set; }
		public string TextBook { get; set; }
		public string ReferenceBook { get; set; }
		public List<CourseChapterResponse> CourseChapters { get; set; }
		public List<CourseOutcomeResponse> CourseOutcomes { get; set; }
		public List<CourseFAQResponse> CourseFAQs { get; set; }
	}
	internal sealed record UpdateCourseMasterCommandHandler(
		ICourseMasterRepository _repository, 
		IMapper _mapper, 
		IUnitOfWork _unitOfWork) : IRequestHandler<UpdateCourseMasterCommand, Result<int>>
	{
		public async Task<Result<int>> Handle(UpdateCourseMasterCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var entity = await _repository.GetByIdAsync(request.Id);
				if(entity == null)
				{
					return Result<int>.Fail("Data not found");
				}
				else
				{
					entity.CourseAssignId = request.CourseAssignId == 0 ? entity.CourseAssignId : request.CourseAssignId;
					entity.TeacherId = request.TeacherId == 0 ? entity.TeacherId : request.TeacherId;
					entity.CourseObjective = request.CourseObjective ?? entity.CourseObjective;
					entity.CourseOutline = request.CourseOutline ?? entity.CourseOutline;
					entity.VideoUrl = request.VideoUrl ?? entity.VideoUrl;
					entity.ThumbnailUrl = request.ThumbnailUrl ?? entity.ThumbnailUrl;
					entity.TextBook = request.TextBook ?? entity.TextBook;
					entity.ReferenceBook = request.ReferenceBook ?? entity.ReferenceBook;
					entity.CourseChapters = _mapper.Map<List<CourseChapter>>(request.CourseChapters);
					entity.CourseOutcomes = _mapper.Map<List<CourseOutcome>>(request.CourseOutcomes);
					entity.CourseFAQs = _mapper.Map<List<CourseFAQ>>(request.CourseFAQs);
					await _repository.UpdateAsync(entity);
					await _unitOfWork.Commit(cancellationToken);
					return Result<int>.Success(request.Id);
				}
			}
			catch (Exception ex)
			{
				return Result<int>.Fail(ex.Message);
			}
			throw new NotImplementedException();
		}
	}
}
