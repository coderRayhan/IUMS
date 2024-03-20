using System;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using AutoMapper;
using IUMS.Application.Features.LMS.ChapterClasses.Queries;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.LMS;
using IUMS.Domain.Entities.LMS;
using MediatR;

namespace IUMS.Application.Features.LMS.ChapterClasses.Commands
{
    public record CreateChapterClassCommand(ChapterClassResponse ChapterClass) : IRequest<Result<int>> { }
	public record CreateChapterClassCommandHandler(IChapterClassRepository _repository, IMapper _mapper, IUnitOfWork _unitOfWork) : IRequestHandler<CreateChapterClassCommand, Result<int>>
	{
		public async Task<Result<int>> Handle(CreateChapterClassCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var mappedData = _mapper.Map<ChapterClass>(request.ChapterClass);
				await _repository.InsertAsync(mappedData);
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
