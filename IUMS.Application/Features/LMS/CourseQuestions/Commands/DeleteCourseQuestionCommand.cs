using System;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.LMS;
using MediatR;

namespace IUMS.Application.Features.LMS.CourseQuestions.Commands
{
    public sealed record DeleteCourseQuestionCommand(int Id) : IRequest<Result<int>>;
	internal sealed record DeleteCourseQuestionCommandHandler(ICourseQuestionRepository _repository, IUnitOfWork _unitOfWork) : IRequestHandler<DeleteCourseQuestionCommand, Result<int>>
	{
		public async Task<Result<int>> Handle(DeleteCourseQuestionCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var entity = await _repository.GetByIdAsync(request.Id);
				if (entity == null)
				{
					return Result<int>.Fail("Data not found");
				}
				await _repository.DeleteAsync(entity);
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
