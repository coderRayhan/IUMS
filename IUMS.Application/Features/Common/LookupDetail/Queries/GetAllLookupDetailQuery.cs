using AspNetCoreHero.Results;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Academic.LookupDetail.Queries;
public sealed record GetAllLookupDetailQuery
: IRequest<Result<IEnumerable<LookupDetailResponse>>>;
internal sealed record GetAllLookupDetailQueryHandler(
    IDapperContext _context)
    : IRequestHandler<GetAllLookupDetailQuery, Result<IEnumerable<LookupDetailResponse>>>
{
    public async Task<Result<IEnumerable<LookupDetailResponse>>> Handle(GetAllLookupDetailQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var sql = "SELECT MD.Id, MD.Name, MD.NameBN, MD.Code, cl.Name AS LookupName, cl.NameBN AS LookupNameBN, MD1.Name AS ParentsName FROM dbo.Com_LookupDetails AS MD LEFT JOIN dbo.Com_LookupDetails AS MD1 ON MD.ParentId = MD1.Id LEFT JOIN dbo.Com_Lookups AS cl ON MD.LookupId = cl.Id ORDER BY MD.CreatedOn DESC";

            using var connection = _context.CreateConnection();

            var lookupDetailList = await connection.QueryAsync<LookupDetailResponse>(sql);

            return Result<IEnumerable<LookupDetailResponse>>.Success(lookupDetailList);

        }
        catch (Exception ex)
        {
            return Result<IEnumerable<LookupDetailResponse>>.Fail(ex.Message);
        }
    }
}
