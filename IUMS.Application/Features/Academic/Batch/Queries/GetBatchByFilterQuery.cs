using AspNetCoreHero.Results;
using AutoMapper;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features
{
    public sealed record GetBatchByFilterQuery(
        int FacultyId, 
        int DepartmentId, 
        int ProgramId, 
        int SessionId) 
        : IRequest<Result<List<BatchResponse>>>;

    internal sealed record GetBatchByFilterQueryHandler(
        IDapperContext _context,
        IMapper _mapper) 
        : IRequestHandler<GetBatchByFilterQuery, Result<List<BatchResponse>>>
    {
        public async Task<Result<List<BatchResponse>>> Handle(GetBatchByFilterQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var sql = "SELECT B.Id, B.BatchName, B.BatchNameBN, B.Code, B.CodeBN, B.Capacity, P.ProgramName, P.ProgramNameBN,   S.SessionName, S.SessionNameBN, F.FacultyName, F.FacultyNameBN, D.DepartmentName, D.DepartmentNameBN,  B.FacultyId,  B.DepartmentId, B.ProgramId FROM dbo.Batches B INNER JOIN dbo.Sessions AS S ON B.SessionId = S.Id INNER JOIN dbo.Faculties AS F ON B.FacultyId = F.Id INNER JOIN dbo.Programs AS P ON B.ProgramId = P.Id INNER JOIN dbo.Departments as D on B.DepartmentId = D.Id WHERE ( 0 = @FacultyId OR D.FacultyId = @FacultyId) AND (0 = @DepartmentId OR B.DepartmentId = @DepartmentId) And (0 = @SessionId OR b.SessionId = @SessionId)and (0 = @ProgramId OR b.ProgramId = @ProgramId) ORDER BY B.Id ASC";

                using var connection = _context.CreateConnection();

                var batchList = await connection.QueryAsync<BatchResponse>(sql, new { request.FacultyId, request.DepartmentId, request.SessionId, request.ProgramId });

                return Result<List<BatchResponse>>.Success(_mapper.Map<List<BatchResponse>>(batchList));
            }
            catch (Exception ex)
            {
                return Result<List<BatchResponse>>.Fail(ex.Message);
            }

        }
    }
}