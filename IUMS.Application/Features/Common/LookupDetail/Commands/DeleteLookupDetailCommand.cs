using AspNetCoreHero.Results;
using AutoMapper;
using IUMS.Application.Constants;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Common;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Academic.LookupDetail.Commands;
public sealed record DeleteLookupDetailCommand(int Id) : IRequest<Result<int>>;

internal sealed record DeleteLookupDetailCommandHandler (
    ILookupDetailRepository _lookupDetailRepository,
    IMapper _mapper,
    IUnitOfWork _unitOfWork)
    : IRequestHandler<DeleteLookupDetailCommand, Result<int>>
{

    public async Task<Result<int>> Handle(DeleteLookupDetailCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _lookupDetailRepository.GetByIdAsync(request.Id);
            await _lookupDetailRepository.DeleteAsync(entity);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(LocalizerConstant.DELETE);
        }
        catch (Exception ex)
        {

            return Result<int>.Fail(ex.Message);
        }
    }
}


