using System;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using AutoMapper;
using IUMS.Application.Features.LMS.CourseChapters.Queries;
using IUMS.Application.Interfaces.Repositories.LMS;
using MediatR;

namespace IUMS.Application.Features.LMS.CourseChapters.Queries
{
    public sealed record CourseChapterByIdQuery(int Id) : IRequest<Result<CourseChapterResponse>>
	{
	}
	internal sealed record GetCourseChapterByIdQueryHandler(ICourseChapterRepository _repository, IMapper _mapper) : IRequestHandler<CourseChapterByIdQuery, Result<CourseChapterResponse>>
	{
		public async Task<Result<CourseChapterResponse>> Handle(CourseChapterByIdQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var entity = await _repository.GetByIdAsync(request.Id);
				if (entity == null)
				{
					return Result<CourseChapterResponse>.Fail("Data not found");
				}
				var mappedEntity = _mapper.Map<CourseChapterResponse>(entity);
				return Result<CourseChapterResponse>.Success(mappedEntity);
			}
			catch (Exception ex)
			{
				return Result<CourseChapterResponse>.Fail(ex.Message);
			}
		}
	}
}
