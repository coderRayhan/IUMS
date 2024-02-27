using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static IUMS.Application.Constants.DBConstants;

namespace UEMS.Application.Features.Academic.Session.Queries.GetAll
{
	public class GetAllActiveSessionQuery:IRequest<Result<List<GetAllSessionResponse>>>
    {
        public GetAllActiveSessionQuery()
        {

        }
    }

    public class GetAllActiveSessionQueryHandler : IRequestHandler<GetAllActiveSessionQuery, Result<List<GetAllSessionResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly IDbRepository _dbRepository;
        public GetAllActiveSessionQueryHandler(IMapper mapper, IDbRepository dbRepository)
        {
            _mapper = mapper;
            _dbRepository = dbRepository;
        }
        public async Task<Result<List<GetAllSessionResponse>>> Handle(GetAllActiveSessionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var sessionList = await _dbRepository.GetListBySp<GetAllSessionResponse>(STORE_PROCEDURE.GET_ALL_ACADEMIC_YEAR);
                var mappedSessions = _mapper.Map<List<GetAllSessionResponse>>(sessionList);
                return Result<List<GetAllSessionResponse>>.Success();
            }
            catch (Exception ex)
            {

                return Result<List<GetAllSessionResponse>>.Fail(ex.Message);
            }
         
        }
    }
}
