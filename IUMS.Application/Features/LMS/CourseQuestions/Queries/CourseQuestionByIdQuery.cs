using System;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using AutoMapper;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.LMS;
using MediatR;

namespace IUMS.Application.Features.LMS.CourseQuestions.Queries
{
    public record CourseQuestionByIdQuery(int Id) : IRequest<Result<CourseQuestionResponse>> { }
	public record CourseQuestionByIdQueryHandler(ICourseQuestionRepository _repository, IMapper _mapper, IUnitOfWork _unitOfWork) : IRequestHandler<CourseQuestionByIdQuery, Result<CourseQuestionResponse>>
	{
		public async Task<Result<CourseQuestionResponse>> Handle(CourseQuestionByIdQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await _repository.GetByIdAsync(request.Id);
				if (data == null)
				{
					return Result<CourseQuestionResponse>.Fail("Data not found");
				}
				else
				{
					var mappedData = _mapper.Map<CourseQuestionResponse>(data);
					return Result<CourseQuestionResponse>.Success(mappedData);
				}
			}
			catch (Exception ex)
			{
				return Result<CourseQuestionResponse>.Fail(ex.Message);
			}
		}
	}
}
