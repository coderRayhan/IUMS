using AspNetCoreHero.Results;
using IUMS.Domain.Entities.Student;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using IUMS.Application.Interfaces.Repositories.Student;
using IUMS.Application.Interfaces.Repositories;

namespace IUMS.Application.Features.Student.StudentBasicInfos.Commands;
public sealed record UpdateStudenStatusCommand(
    int Id)
    : IRequest<Result<int>>;

internal sealed record UpdateStudenStatusCommandHandler(
    IStudentBasicInfoRepository _repository,
    IUnitOfWork _unitOfWork)
    : IRequestHandler<UpdateStudentBasicInfoCommand, Result<int>>
{
    public async Task<Result<int>> Handle(UpdateStudentBasicInfoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            StudentBasicInfo studentBasicInfo = await _repository.GetByIdAsync(request.Id);

            if (studentBasicInfo == null)
                return Result<int>.Fail("Data not found");

            studentBasicInfo.IsActive = !studentBasicInfo.IsActive;

            await _repository.UpdateAsync(studentBasicInfo);

            await _unitOfWork.Commit(cancellationToken);

            return Result<int>.Success(studentBasicInfo.Id);
        }
        catch (Exception ex)
        {
            return Result<int>.Fail(ex.Message);
        }
    }
}