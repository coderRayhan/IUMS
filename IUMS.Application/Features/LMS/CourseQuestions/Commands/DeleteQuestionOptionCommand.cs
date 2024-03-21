using System;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.LMS;
using MediatR;

namespace IUMS.Application.Features.LMS.CourseQuestions.Commands
{
    public sealed record DeleteQuestionOptionCommand(int Id) : IRequest<Result<int>>
	{
	}
	internal sealed record DeleteQuestionOptionCommandHandler(IQuestionOptionRepository _repository, IUnitOfWork _unitOfWork) : IRequestHandler<DeleteQuestionOptionCommand, Result<int>>
	{
		public async Task<Result<int>> Handle(DeleteQuestionOptionCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var entity = await _repository.GetByIdAsync(request.Id);
				if(entity == null)
				{
					return Result<int>.Fail("Data not found");
				}
				await _repository.DeleteAsync(entity);
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
