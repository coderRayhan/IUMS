using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using AutoMapper;
using IUMS.Application.Features.LMS.CourseChapters.Queries;
using IUMS.Application.Features.LMS.CourseOutcomes.Queries;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.LMS;
using IUMS.Domain.Entities.LMS;
using MediatR;

namespace IUMS.Application.Features.LMS.CourseMasters.Queries
{
    public sealed class CreateCourseMasterCommand : IRequest<Result<int>>
    {
        public int CourseAssignId { get; set; }
        public int PartId { get; set; }
        public int TeacherId { get; set; }
        public string CourseObjective { get; set; }
        public string CourseOutline { get; set; }
        public string VideoUrl { get; set; }
        public string ThumbnailUrl { get; set; }
		public string TextBook { get; set; }
		public string ReferenceBook { get; set; }
		public List<CourseChapterResponse> CourseChapters { get; set; }
        public List<CourseOutcomeResponse> CourseOutcomes { get; set; }
        public List<CourseFAQResponse> CourseFAQs { get; set; }
    }
    internal sealed record CreateCourseMasterCommandHandler(
        ICourseMasterRepository _repository, 
        IMapper _mapper, 
        IUnitOfWork _unitOfWork) : IRequestHandler<CreateCourseMasterCommand, Result<int>>
    {
        public async Task<Result<int>> Handle(CreateCourseMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var allCourse = await _repository.GetListAsync();
                if (allCourse.Any(ac => ac.CourseAssignId == request.CourseAssignId))
                    return Result<int>.Fail("Course exists");
                var mappedEntity = _mapper.Map<CourseMaster>(request);
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
