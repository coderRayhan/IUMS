using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using IUMS.Application.Interfaces.Repositories.Academic;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Constants;

namespace IUMS.Application.Features.Academic.Courses.Commands;
public sealed record DeleteCourseCommand(int Id) : IRequest<Result<int>>;
internal sealed record DeleteCourseCommandHandler(
    ICourseRepository _repository, IUnitOfWork _unitOfWork) : IRequestHandler<DeleteCourseCommand, Result<int>>
{
    public async Task<Result<int>> Handle(DeleteCourseCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity is null)
            {
                return Result<int>.Fail("Course not found");
            }

            await _repository.DeleteAsync(entity);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(LocalizerConstant.DELETE);
        }
        catch (Exception ex)
        {
            return Result<int>.Fail(ex.Message);
        }
    }
}
