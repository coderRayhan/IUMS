using AspNetCoreHero.Results;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Student.StudentBasicInfos.Queries;
public sealed record StudentListQuery(
    int SessionId,
    int BatchId,
    int SemesterId)
    : IRequest<Result<IEnumerable<StudentBasicInfoResponse>>>;

internal sealed record StudentListQueryHandler(
    IDapperContext _dapperContext)
    : IRequestHandler<StudentListQuery, Result<IEnumerable<StudentBasicInfoResponse>>>
{
    public async Task<Result<IEnumerable<StudentBasicInfoResponse>>> Handle(StudentListQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var sql = "SELECT SB.Id, ClassRollNo, RegistrationNumber, DateOfAdmission, StudentName, FatherName, S.SessionName, S.SessionNameBN, P.ProgramName, P.ProgramNameBN, B.BatchName, B.BatchNameBN FROM Std_StudentBasicInfos SB INNER JOIN Aca_Sessions S ON SB.SessionId = S.Id INNER JOIN Aca_Programs P ON SB.ProgramId = P.Id INNER JOIN Aca_Batches B ON SB.BatchId = B.Id WHERE SB.SessionId = @SessionId AND SB.BatchId = @BatchId AND (0 = @SemesterId OR SB.SemesterId = @SemesterId)";

            using var connection = _dapperContext.CreateConnection();

            IEnumerable<StudentBasicInfoResponse> studentBasicInfos = await connection.QueryAsync<StudentBasicInfoResponse>(sql, new {request.SessionId, request.BatchId, request.SemesterId});

            return Result<IEnumerable<StudentBasicInfoResponse>>.Success(studentBasicInfos);
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<StudentBasicInfoResponse>>.Fail(ex.Message);
        }
    }
}
