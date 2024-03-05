using AspNetCoreHero.Results;
using AutoMapper;
using IUMS.Application.Interfaces.Repositories.Student;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Student.StudentBasicInfos.Queries;
public sealed record StudentByIdQuery(
    int Id) 
    : IRequest<Result<StudentBasicInfoResponse>>;

internal sealed record StudentByIdQueryHandler(
    IStudentBasicInfoRepository _studentBasicInfoRepository,
    IMapper _mapper)
    : IRequestHandler<StudentByIdQuery, Result<StudentBasicInfoResponse>>
{
    public async Task<Result<StudentBasicInfoResponse>> Handle(StudentByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var student = await _studentBasicInfoRepository.GetByIdAsync(request.Id);
            if(student == null)
            {
                return Result<StudentBasicInfoResponse>.Fail("Data not found");
            }

            var mappedStudent = _mapper.Map<StudentBasicInfoResponse>(student);
            
            return Result<StudentBasicInfoResponse>.Success(mappedStudent);
        }
        catch (Exception ex)
        {
            return Result<StudentBasicInfoResponse>.Fail(ex.Message);
        }
    }
}