using AspNetCoreHero.Results;
using IUMS.Application.Constants;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Academic;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features
{
    public record DeleteBatchCommand(int Id) : IRequest<Result<int>>;
    public record DeletebatchCommandHandler(IBatchRepository _repository, IUnitOfWork _unitOfWork) : IRequestHandler<DeleteBatchCommand, Result<int>>
    {
        public async Task<Result<int>> Handle(DeleteBatchCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(command.Id);
                await _repository.DeleteAsync(entity);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(LocalizerConstant.DELETE);
            }
            catch (Exception ex)
            {
                return Result<int>.Fail(ex.Message);
            }
        }
    }
}