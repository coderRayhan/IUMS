using AspNetCoreHero.Results;
using AutoMapper;
using IUMS.Application.Interfaces.Repositories.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Academic.Lookup.Queries;
public sealed record GetLookupByIdQuery(int Id) : IRequest<Result<LookupResponse>>;
internal sealed record GetLookupByIdQueryQueryHandler
    : IRequestHandler<GetLookupByIdQuery, Result<LookupResponse>>
{
    private readonly ILookupRepository _lookupRepository;
    private readonly IMapper _mapper;

    public GetLookupByIdQueryQueryHandler(ILookupRepository lookupRepository, IMapper mapper)
    {
        _lookupRepository = lookupRepository;
        _mapper = mapper;
    }
    public async Task<Result<LookupResponse>> Handle(GetLookupByIdQuery request, CancellationToken cancellationToken)
    {
        var lookup = await _lookupRepository.GetByIdAsync(request.Id);
        var maapedLookup = _mapper.Map<LookupResponse>(lookup);
        return Result<LookupResponse>.Success(maapedLookup);

    }
}

