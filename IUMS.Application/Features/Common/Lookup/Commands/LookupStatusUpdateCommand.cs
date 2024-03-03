using AspNetCoreHero.Results;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Common;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using IUMS.Application.Constants;

namespace IUMS.Application.Features.Academic.Lookup.Commands;
public sealed record LookupStatusUpdateCommand(int Id) : IRequest<Result<int>>;
internal sealed record LookupStatusUpdateCommandHandler : IRequestHandler<LookupStatusUpdateCommand, Result<int>>
{
    private readonly ILookupRepository _lookupRepository;
    private readonly ILookupDetailRepository _lookupDetailRepository;
    private IUnitOfWork _unitOfWork { get; set; }
    public LookupStatusUpdateCommandHandler(
        ILookupRepository lookupRepository, 
        IUnitOfWork unitOfWork, 
        ILookupDetailRepository lookupDetailRepository)
    {
        _lookupRepository = lookupRepository;
        _unitOfWork = unitOfWork;
        _lookupDetailRepository = lookupDetailRepository;
    }
    public async Task<Result<int>> Handle(LookupStatusUpdateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var lookup = await _lookupRepository.GetByIdAsync(request.Id);

            if (lookup is null)
                return Result<int>.Fail("Data not found");

            lookup.Status = lookup.Status == "A" ? "In" : "A";

            //var lookupDetails = await _lookupDetailRepository.GetListAsync();
            //var childDetail = lookupDetails.Where(ld => ld.LookupId == lookup.Id);
            //childDetail.ForAll(ld => ld.Status = lookup.Status);

            await _lookupRepository.UpdateAsync(lookup);

            //await _lookupDetailRepository.AddOrUpdateRangeAsync(childDetail);

            await _unitOfWork.Commit(cancellationToken);

            return Result<int>.Success(LocalizerConstant.UPDATE);
        }
        catch (Exception ex)
        {

            return Result<int>.Fail(ex.Message);
        }

    }
}
