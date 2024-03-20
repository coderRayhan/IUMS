using System;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.LMS;
using MediatR;

namespace IUMS.Application.Features.LMS.ChapterClasses.Commands
{
    public record DeleteChapterClassCommand(int Id) : IRequest<Result<int>> { }
	public record DeleteChapterClassCommandHandler(IChapterClassRepository _repository, IUnitOfWork _unitOfWork) : IRequestHandler<DeleteChapterClassCommand, Result<int>>
	{
		public async Task<Result<int>> Handle(DeleteChapterClassCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var entity = await _repository.GetByIdAsync(request.Id);
				if(entity == null)
					return Result<int>.Fail("Data not found");
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
