using AspNetCoreHero.Results;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Academic.Lookup.Queries;
public sealed record GetAllLookupQuery : IRequest<Result<IEnumerable<LookupResponse>>>;
internal sealed record GetAllLookupQueryHandler(
    IDapperContext _dapperContext)
    : IRequestHandler<GetAllLookupQuery, Result<IEnumerable<LookupResponse>>>
{
    public async Task<Result<IEnumerable<LookupResponse>>> Handle(GetAllLookupQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var sql = "SELECT cl1.*, cl2.Name AS ParentsName FROM dbo.Com_Lookups cl1 LEFT JOIN dbo.Com_Lookups cl2 ON cl1.ParentId = cl2.Id ORDER BY cl1.CreatedOn DESC";

            using var connection = _dapperContext.CreateConnection();

            var lookupList = await connection.QueryAsync<LookupResponse>(sql);

            return Result<IEnumerable<LookupResponse>>.Success(lookupList);
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<LookupResponse>>.Fail(ex.Message);
        }
    }
}
