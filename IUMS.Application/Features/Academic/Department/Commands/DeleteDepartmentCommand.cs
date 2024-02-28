using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using IUMS.Application.Interfaces.Repositories.Academic;
using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using IUMS.Application.Constants;
using IUMS.Application.Interfaces.Repositories;

namespace IUMS.Application.Features
{
    public record DeleteDepartmentCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

    }
    public record DeleteDepartmentCommandHandler(
        IDepartmentRepository Repository,
        IUnitOfWork UnitOfWork) : IRequestHandler<DeleteDepartmentCommand, Result<int>>
    {
        public async Task<Result<int>> Handle(DeleteDepartmentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await Repository.GetByIdAsync(command.Id);
                await Repository.DeleteAsync(entity);
                await UnitOfWork.Commit(cancellationToken);
                return Result<int>.Success(LocalizerConstant.DELETE);
            }
            catch (Exception ex)
            {
                return Result<int>.Fail(ex.Message);
            }
        }
    }
}