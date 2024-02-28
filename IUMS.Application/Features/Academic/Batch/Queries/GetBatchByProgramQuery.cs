using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;
using static IUMS.Application.Constants.DBConstants;

namespace IUMS.Application.Features.Academic.Batch.Queries
{
    public sealed record GetBatchByProgramQuery(
        int SessionId, 
        int ProgramId) 
        : IRequest<Result<IEnumerable<GetBatchByProgramResponse>>>;

    internal sealed record GetBatchByProgramQueryHandler(
        IDapperContext _context)
        : IRequestHandler<GetBatchByProgramQuery, Result<IEnumerable<GetBatchByProgramResponse>>>
    {
        public async Task<Result<IEnumerable<GetBatchByProgramResponse>>> Handle(GetBatchByProgramQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var sql = "SELECT B.Id, B.BatchName, B.BatchNameBN FROM dbo.Aca_Batches B WHERE B.ProgramId = @programId AND B.SessionId = @admissionYearId";

                using var connection = _context.CreateConnection();

                var list = await connection.QueryAsync<GetBatchByProgramResponse>(sql, new { request.SessionId, request.ProgramId });

                return Result<IEnumerable<GetBatchByProgramResponse>>.Success(list);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<GetBatchByProgramResponse>>.Fail(ex.Message);
            }
        }
    }
}
