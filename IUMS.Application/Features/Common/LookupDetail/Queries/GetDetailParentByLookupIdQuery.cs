using AspNetCoreHero.Results;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Academic.LookupDetail.Queries;
public sealed record GetDetailParentByLookupIdQuery(
    int Id) 
    : IRequest<Result<IEnumerable<LookupDetailResponse>>>;
internal sealed record GetDetailParentByLookupIdQueryHandler(
    IDapperContext _dapperContext)
    : IRequestHandler<GetDetailParentByLookupIdQuery, Result<IEnumerable<LookupDetailResponse>>>
{
    public async Task<Result<IEnumerable<LookupDetailResponse>>> Handle(GetDetailParentByLookupIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var sql = "SELECT cld.Id, cld.Name, cld.NameBN FROM   dbo.Com_Lookups AS cl INNER JOIN dbo.Com_LookupDetails AS cld  ON cl.ParentId = cld.LookupId WHERE (0= @Id or cl.Id = @Id) AND cld.Status = 'A' ORDER BY cld.Name";

            using var connection = _dapperContext.CreateConnection();

            var lookupDetailList = await connection.QueryAsync<LookupDetailResponse>(sql, new { request.Id });
            return Result<IEnumerable<LookupDetailResponse>>.Success(lookupDetailList);
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<LookupDetailResponse>>.Fail(ex.Message);
        }
    }
}

