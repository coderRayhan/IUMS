using AspNetCoreHero.Results;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Academic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Academic.CourseAssigns.Commands;
public sealed record DeleteCourseAssignCommand(
    int Id)
    : IRequest<Result<int>>;

internal sealed record DeleteCourseAssignCommandHandler(
    ICourseAssignRepository _repository,
    IUnitOfWork _unitOfWork)
    : IRequestHandler<DeleteCourseAssignCommand, Result<int>>
{
    public async Task<Result<int>> Handle(DeleteCourseAssignCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            if (entity is null)
                return Result<int>.Fail("Data not found");

            await _repository.DeleteAsync(entity);

            await _unitOfWork.Commit(cancellationToken);
        }
        catch (Exception ex)
        {

            throw;
        }
        throw new NotImplementedException();
    }
}
