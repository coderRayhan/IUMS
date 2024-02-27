using AspNetCoreHero.Results;
using AutoMapper;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static IUMS.Application.Constants.DBConstants;

namespace IUMS.Application.Features.Academic
{
	public record GetAllActiveSessionQuery:IRequest<Result<List<GetAllSessionResponse>>>;

    public class GetAllActiveSessionQueryHandler : IRequestHandler<GetAllActiveSessionQuery, Result<List<GetAllSessionResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly IDapperContext _context;
        public GetAllActiveSessionQueryHandler(IMapper mapper, IDapperContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<Result<List<GetAllSessionResponse>>> Handle(GetAllActiveSessionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var query = QUERIES.GET_ALL_SESSION;

                IEnumerable<GetAllSessionResponse> sessionList;

                using (var connection = _context.CreateConnection())
                {
                    sessionList = await connection.QueryAsync<GetAllSessionResponse>(query);
                }

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
