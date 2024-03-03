using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;

namespace IUMS.Application.Features.Academic.LookupDetail.Queries;
public sealed record GetDetailByParentIdQuery(
    string Type,
    int ParentId)
: IRequest<Result<IEnumerable<GetAllDetailByParentIdResponse>>>;

internal sealed record GetDetailByParentIdQueryHandler(
    IDapperContext _context)
: IRequestHandler<GetDetailByParentIdQuery, Result<IEnumerable<GetAllDetailByParentIdResponse>>>
{
    public async Task<Result<IEnumerable<GetAllDetailByParentIdResponse>>> Handle(GetDetailByParentIdQuery command, CancellationToken cancellationToken)
    {
        try
        {
            var sql = "SELECT LD.* FROM   Com_Lookups L INNER JOIN Com_LookupDetails LD ON L.Id = LD.LookupId  WHERE L.Name=@LookupName AND LD.ParentId = @ParentId";

            using var connection = _context.CreateConnection();

            var roomList = await connection.QueryAsync<GetAllDetailByParentIdResponse>(sql, new { command.Type, command.ParentId });
            return Result<IEnumerable<GetAllDetailByParentIdResponse>>.Success(roomList);
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<GetAllDetailByParentIdResponse>>.Fail(ex.Message);
        }
    }
}

