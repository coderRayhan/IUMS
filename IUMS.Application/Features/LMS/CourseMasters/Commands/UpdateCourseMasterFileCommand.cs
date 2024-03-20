using System;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using AutoMapper;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.LMS;
using MediatR;

namespace IUMS.Application.Features.LMS.CourseMasters.Commands
{
    public sealed record UpdateCourseMasterFileCommand : IRequest<Result<int>>
	{
		public int Id { get; set; }
		public string VideoUrl { get; set; }
		public string ThumbnailUrl { get; set; }

	}
	internal sealed record UpdateCourseMasterFileCommandHandler(
		ICourseMasterRepository _repository, 
		IMapper _mapper, 
		IUnitOfWork _unitOfWork) : IRequestHandler<UpdateCourseMasterFileCommand, Result<int>>
	{
		public async Task<Result<int>> Handle(UpdateCourseMasterFileCommand request, CancellationToken cancellationToken)
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
					entity.VideoUrl = request.VideoUrl ?? entity.VideoUrl;
					entity.ThumbnailUrl = request.ThumbnailUrl ?? entity.ThumbnailUrl;
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
