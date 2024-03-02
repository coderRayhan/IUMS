using AspNetCoreHero.Results;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features
{
    public sealed record GetBatchByIdQuery(int Id) 
        : IRequest<Result<BatchResponse>>;
    internal sealed record GetBatchByIdQueryHandler(
        IDapperContext _context) 
        : IRequestHandler<GetBatchByIdQuery, Result<BatchResponse>>
    {
        public async Task<Result<BatchResponse>> Handle(GetBatchByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var sql = "SELECT B.Id, B.BatchName, B.BatchNameBN, B.Code, B.Capacity, P.ProgramName, P.ProgramNameBN,   S.SessionName, S.SessionNameBN, F.FacultyName , F.FacultyNameBN, D.DepartmentName, D.DepartmentNameBN, B.FacultyId,  B.DepartmentId, B.ProgramId, B.SessionId FROM dbo.Aca_Batches B LEFT join dbo.Aca_Sessions as S on B.SessionId = S.Id LEFT join dbo.Aca_Programs as P on B.ProgramId = P.Id LEFT join dbo.Aca_Faculties as F on  F.Id = B.FacultyId LEFT join dbo.Aca_Departments as D on  D.Id = B.DepartmentId WHERE B.Id = @Id";

                using var connection = _context.CreateConnection();

                var res = await connection.QueryFirstOrDefaultAsync<BatchResponse>(sql, new { query.Id });

                return Result<BatchResponse>.Success(res);
            }
            catch (Exception ex)
            {
                return Result<BatchResponse>.Fail(ex.Message);
            }
        }
    }
}
