using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;

namespace IUMS.Application.Features.Common.Queries
{
    public record CommonDropdownQuery(string Query, object[] Params = null) : IRequest<Result<IEnumerable<CommonDropdownResponse>>>;
    public record CommonDropdownQueryHandler(IDapperContext _context) : IRequestHandler<CommonDropdownQuery, Result<IEnumerable<CommonDropdownResponse>>>
    {
        public async Task<Result<IEnumerable<CommonDropdownResponse>>> Handle(CommonDropdownQuery request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<CommonDropdownResponse> list;

                using var connection = _context.CreateConnection();

                if(request.Params is null)
                    list = await connection.QueryAsync<CommonDropdownResponse>(request.Query);
                else
                    list = await connection.QueryAsync<CommonDropdownResponse>(String.Format(request.Query, request.Params));

                return await Result<IEnumerable<CommonDropdownResponse>>.SuccessAsync(list);
            }
            catch (Exception ex)
            {
                return await Result<IEnumerable<CommonDropdownResponse>>.FailAsync(ex.Message);
            }
        }
    }
}
