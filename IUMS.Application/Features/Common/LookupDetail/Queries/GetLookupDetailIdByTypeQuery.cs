using System;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;

namespace IUMS.Application.Features.Academic.LookupDetail.Queries;
public sealed record GetLookupDetailIdByTypeQuery(string Type) : IRequest<Result<int>>;
internal sealed record GetLookupDetailIdByTypeQueryHandler(
    IDapperContext _dapperContext)
    : IRequestHandler<GetLookupDetailIdByTypeQuery, Result<int>>
{
    public async Task<Result<int>> Handle(GetLookupDetailIdByTypeQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var sql = "SELECT Id FROM Com_LookupDetails WHERE LOWER(REPLACE(Name,' ','')) = LOWER(REPLACE(@type,' ',''))";

            using var connection = _dapperContext.CreateConnection();

            var id = await connection.ExecuteScalarAsync<int>(sql);

            return Result<int>.Success(id);
        }
        catch (Exception ex)
        {
            return Result<int>.Fail(ex.Message);
        }
    }
}

