using AspNetCoreHero.Results;
using AutoMapper;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using static IUMS.Application.Constants.DBConstants;

namespace IUMS.Application.Features.Academic.Program.Queries
{
    public sealed record GetProgramByIdQuery(
        int Id)
        : IRequest<Result<ProgramResponse>>;
    internal sealed record GetProgramByIdQueryHandler(
        IDapperContext _context,
        IMapper _mapper) 
        : IRequestHandler<GetProgramByIdQuery, Result<ProgramResponse>>
    {
        public async Task<Result<ProgramResponse>> Handle(
            GetProgramByIdQuery query, 
            CancellationToken cancellationToken)
        {
            try
            {
                var sql = "SELECT P.Id,  P.ProgramName, P.ProgramNameBN, P.Code, P.CreditPoints, P.YearDuration, D.DepartmentName, D.DepartmentNameBN, P.DepartmentId, D.FacultyId FROM dbo.Aca_Programs AS P LEFT join dbo.Aca_Departments as D on  D.Id = P.DepartmentId LEFT JOIN dbo.Aca_Faculties F ON D.FacultyId = F.Id where p.Id = @Id";

                using var connection = _context.CreateConnection();

                var program = await connection.QueryFirstOrDefaultAsync<ProgramResponse>(sql, new { query.Id });

                var mappedProgram = _mapper.Map<ProgramResponse>(program);

                return Result<ProgramResponse>.Success(mappedProgram);
            }
            catch (Exception ex)
            {

                return Result<ProgramResponse>.Fail(ex.Message);
            }

        }
    }
}
