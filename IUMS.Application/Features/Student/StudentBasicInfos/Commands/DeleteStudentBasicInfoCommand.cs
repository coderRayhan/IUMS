using AspNetCoreHero.Results;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Student;
using IUMS.Domain.Entities.Student;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Student.StudentBasicInfos.Commands;
public sealed record DeleteStudentBasicInfoCommand(
    int Id)
    : IRequest<Result<int>>;

internal sealed record DeleteStudentBasicInfoCommandHandler(
    IStudentBasicInfoRepository _repository,
    IUnitOfWork _unitOfWork)
    : IRequestHandler<DeleteStudentBasicInfoCommand, Result<int>>
{
    public async Task<Result<int>> Handle(DeleteStudentBasicInfoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            StudentBasicInfo studentBasicInfo = await _repository.GetByIdAsync(request.Id);

            if (studentBasicInfo == null)
                return Result<int>.Fail("Data not found");

            await _repository.DeleteAsync(studentBasicInfo);

            await _unitOfWork.Commit(cancellationToken);

            return Result<int>.Success(0);
        }
        catch (Exception ex)
        {
            return Result<int>.Fail(ex.Message);
        }
    }
}
