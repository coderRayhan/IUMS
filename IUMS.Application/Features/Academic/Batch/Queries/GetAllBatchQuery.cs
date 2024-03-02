using AspNetCoreHero.Results;
using AutoMapper;
using Dapper;
using IUMS.Application.Features;
using IUMS.Application.Interfaces.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features
{
    public sealed record GetAllBatchQuery(
        int FacultyId,
        int DepartmentId,
        int ProgramId)
        : IRequest<Result<List<BatchResponse>>>;
    internal sealed record GetAllBatchQueryHandler(
        IDapperContext _context,
        IMapper _mapper) : IRequestHandler<GetAllBatchQuery, Result<List<BatchResponse>>>
    {
        public async Task<Result<List<BatchResponse>>> Handle(GetAllBatchQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var sql = "SELECT B.Id, B.BatchName, B.BatchNameBN, B.Code, B.Capacity, P.ProgramName, P.ProgramNameBN,   S.SessionName, S.SessionNameBN, F.FacultyName , F.FacultyNameBN, D.DepartmentName, D.DepartmentNameBN, B.FacultyId,  B.DepartmentId, B.ProgramId, B.SessionId FROM dbo.Aca_Batches as B lEFT JOIN dbo.Aca_Sessions as S on B.SessionId = S.Id LEFT JOIN dbo.Aca_Programs as P on B.ProgramId = P.Id LEFT JOIN dbo.Aca_Faculties as F on  F.Id = B.FacultyId LEFT JOIN dbo.Aca_Departments as D on  D.Id = B.DepartmentId WHERE (0 = @FacultyId OR B.FacultyId = @FacultyId) AND (0 = @DepartmentId OR B.DepartmentId = @DepartmentId) AND (0 = @ProgramId OR B.ProgramId = @ProgramId) ORDER BY B.Id DESC";

                using var connection = _context.CreateConnection();

                var batchList = await connection.QueryAsync<BatchResponse>(sql, new { request.FacultyId, request.DepartmentId, request.ProgramId });

                return Result<List<BatchResponse>>.Success(_mapper.Map<List<BatchResponse>>(batchList));
            }
            catch (Exception ex)
            {
                return Result<List<BatchResponse>>.Fail(ex.Message);
            }

        }


    }
}
