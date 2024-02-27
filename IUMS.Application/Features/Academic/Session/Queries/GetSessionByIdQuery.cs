using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using static IUMS.Application.Constants.DBConstants;

namespace UEMS.Application.Features.Academic.Session.Queries
{
	public class GetSessionByIdQuery : IRequest<Result<GetAllSessionResponse>>
    {
        public int Id { get; set; }

        public class GetSessionByIdQueryHandler : IRequestHandler<GetSessionByIdQuery, Result<GetAllSessionResponse>>
        {
            private readonly IMapper _mapper;
            private readonly IDbRepository _dbRepository;

            public GetSessionByIdQueryHandler(IMapper mapper, IDbRepository dbRepository)
            {
                _mapper = mapper;
                _dbRepository = dbRepository;
            }

            public async Task<Result<GetAllSessionResponse>> Handle(GetSessionByIdQuery query, CancellationToken cancellationToken)
            {
                try
                {
                    var session = await _dbRepository.GetObjectBySpWithParam<GetAllSessionResponse>(STORE_PROCEDURE.GET_ACADEMIC_YEAR_BY_ID, query.Id);
                    var mappedSession = _mapper.Map<GetAllSessionResponse>(session);
                    return Result<GetAllSessionResponse>.Success(mappedSession);
                }
                catch (Exception ex)
                {

                    return Result<GetAllSessionResponse>.Fail(ex.Message);
                }
            
            }
        }
    }
}
