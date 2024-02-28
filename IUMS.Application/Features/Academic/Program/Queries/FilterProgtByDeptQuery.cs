using AspNetCoreHero.Results;
using AutoMapper;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Academic.Program.Queries
{
    public sealed record FilterProgtByDeptQuery(
        int DepartmentId)
        : IRequest<Result<List<GetProgByDeptResponse>>>;

    internal sealed record FilterProgtByDeptQueryHandler(
        IDapperContext _context,
        IMapper _mapper)
        : IRequestHandler<FilterProgtByDeptQuery, Result<List<GetProgByDeptResponse>>>
    {
        public async Task<Result<List<GetProgByDeptResponse>>> Handle(FilterProgtByDeptQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var sql = "SELECT P.Id,  P.ProgramName, P.ProgramNameBN, p.DepartmentId, P.Code FROM dbo.Aca_Programs AS P LEFT join dbo.Aca_Departments as D on  D.Id = P.DepartmentId where P.DepartmentId = @DepartmentId";

                using var connection = _context.CreateConnection();

                var list = await connection.QueryAsync<GetProgByDeptResponse>(sql, new { request.DepartmentId });

                return Result<List<GetProgByDeptResponse>>.Success(_mapper.Map<List<GetProgByDeptResponse>>(list));
            }
            catch (Exception ex)
            {
                return Result<List<GetProgByDeptResponse>>.Fail(ex.Message);
            }

        }
    }
}
