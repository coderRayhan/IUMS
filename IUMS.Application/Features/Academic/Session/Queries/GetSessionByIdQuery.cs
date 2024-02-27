using AspNetCoreHero.Results;
using AutoMapper;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using static IUMS.Application.Constants.DBConstants;

namespace IUMS.Application.Features.Academic
{
	public class GetSessionByIdQuery : IRequest<Result<GetAllSessionResponse>>
    {
        public int Id { get; set; }

        public class GetSessionByIdQueryHandler : IRequestHandler<GetSessionByIdQuery, Result<GetAllSessionResponse>>
        {
            private readonly IMapper _mapper;
            private readonly IDapperContext _context;

            public GetSessionByIdQueryHandler(IMapper mapper, IDapperContext context)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<GetAllSessionResponse>> Handle(GetSessionByIdQuery query, CancellationToken cancellationToken)
            {
                try
                {
                    var sql = QUERIES.GET_SESSION_BY_ID;

                    using var connection = _context.CreateConnection();

                    var session = await connection.QueryFirstOrDefaultAsync<GetAllSessionResponse>(sql, new { query.Id });

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
