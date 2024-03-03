using AspNetCoreHero.Results;
using AutoMapper;
using IUMS.Application.Interfaces.Repositories.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Academic.LookupDetail.Queries;
public sealed record GetLookupDetailByIdQuery(int Id) : IRequest<Result<LookupDetailResponse>>;
    internal sealed record GetLookupDetailByIdQueryHandler(
        ILookupDetailRepository _lookupDetailRepository,
        IMapper _mapper)
    : IRequestHandler<GetLookupDetailByIdQuery, Result<LookupDetailResponse>>
    {
        public async Task<Result<LookupDetailResponse>> Handle(GetLookupDetailByIdQuery request, CancellationToken cancellationToken)
        {
            var lookupDetail = await _lookupDetailRepository.GetByIdAsync(request.Id);
            var maapedLookupDetail = _mapper.Map<LookupDetailResponse>(lookupDetail);
            return Result<LookupDetailResponse>.Success(maapedLookupDetail);
        }


    }

