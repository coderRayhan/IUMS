using AspNetCoreHero.Results;
using IUMS.Application.Constants;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Common;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Academic.LookupDetail.Commands;
public sealed record LookupDetailStatusUpdateCommand(int Id) : IRequest<Result<int>>;

internal sealed record LookupDetailStatusUpdateCommandHandler(
    ILookupRepository _lookupRepository,
    ILookupDetailRepository _lookupDetailRepository,
    IUnitOfWork _unitOfWork)
    : IRequestHandler<LookupDetailStatusUpdateCommand, Result<int>>
{
    public async Task<Result<int>> Handle(LookupDetailStatusUpdateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var lookupDetail = await _lookupDetailRepository.GetByIdAsync(request.Id);
            var lookup = await _lookupRepository.GetByIdAsync(lookupDetail.LookupId);
            if (lookup != null && lookup.Status == "A")
            {
                lookupDetail.Status = lookupDetail.Status == "A" ? "In" : "A";
                await _lookupDetailRepository.UpdateAsync(lookupDetail);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(LocalizerConstant.UPDATE);
            }
            else
            {
                return Result<int>.Fail("Lookup Detail's status can't be changed while Master is inactive");
            }

        }
        catch (Exception ex)
        {
            return Result<int>.Fail(ex.Message);
        }
    }
}

