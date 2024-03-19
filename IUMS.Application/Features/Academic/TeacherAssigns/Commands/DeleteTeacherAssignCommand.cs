using AspNetCoreHero.Results;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Academic;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Academic.TeacherAssigns.Commands;
public sealed record DeleteTeacherAssignCommand(
    int Id)
    : IRequest<Result<int>>;

internal sealed record DeleteTeacherAssignCommandHandler(
	ITeacherAssignRepository _repository,
	IUnitOfWork _unitOfWork)
    : IRequestHandler<DeleteTeacherAssignCommand, Result<int>>
{
    public async Task<Result<int>> Handle(DeleteTeacherAssignCommand request, CancellationToken cancellationToken)
    {
		try
		{
            var entity = await _repository.GetByIdAsync(request.Id);

            if (entity is null)
                return Result<int>.Fail("Data not found");

            await _repository.DeleteAsync(entity);

            await _unitOfWork.Commit(cancellationToken);

            return Result<int>.Success();
        }
		catch (Exception ex)
		{
            return Result<int>.Fail(ex.Message);    
		}
    }
}
