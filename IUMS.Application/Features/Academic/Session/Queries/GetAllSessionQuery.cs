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
	public class GetAllSessionQuery:IRequest<Result<List<GetAllSessionResponse>>>
    {
        public GetAllSessionQuery()
        {

        }
    }

    public class GetAllSessionQueryHandler : IRequestHandler<GetAllSessionQuery, Result<List<GetAllSessionResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly IDbRepository _dbRepository;
        public GetAllSessionQueryHandler(IMapper mapper, IDbRepository dbRepository)
        {
            _mapper = mapper;
            _dbRepository = dbRepository;
        }
        public async Task<Result<List<GetAllSessionResponse>>> Handle(GetAllSessionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var sessionList = await _dbRepository.GetListBySp<GetAllSessionResponse>(STORE_PROCEDURE.GET_ALL_ACADEMIC_YEAR);
                var mappedSessions = _mapper.Map<List<GetAllSessionResponse>>(sessionList);
                return Result<List<GetAllSessionResponse>>.Success(mappedSessions);
            }
            catch (Exception ex)
            {

                return Result<List<GetAllSessionResponse>>.Fail(ex.Message);
            }
         
        }
    }
}
