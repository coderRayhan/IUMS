using AspNetCoreHero.Results;
using AutoMapper;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Academic.Program.Queries.GetAll
{
    public sealed record GetAllProgramQuery
        : IRequest<Result<List<GetAllProgramResponse>>>;
    internal sealed record GetAllProgramQueryHandler(
        IDapperContext _context,
        IMapper _mapper)
    : IRequestHandler<GetAllProgramQuery, Result<List<GetAllProgramResponse>>>
    {
        public async Task<Result<List<GetAllProgramResponse>>> Handle(GetAllProgramQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var sql = "SELECT P.Id,  P.ProgramName, P.ProgramNameBN, P.Code, P.CreditPoints, P.YearDuration, D.DepartmentName, D.DepartmentNameBN, P.DepartmentId FROM dbo.Aca_Programs AS P LEFT JOIN dbo.Aca_Departments as D on  D.Id = P.DepartmentId ORDER BY  P.Id  DESC";

                using var connection = _context.CreateConnection();

                var data = await connection.QueryAsync<GetAllProgramResponse>(sql);

                var mappedList = _mapper.Map<List<GetAllProgramResponse>>(data);

                return Result<List<GetAllProgramResponse>>.Success(mappedList);
            }
            catch (Exception ex)
            {
                return Result<List<GetAllProgramResponse>>.Fail(ex.Message);
            }

        }
    }
}