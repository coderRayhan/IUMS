using AspNetCoreHero.Results;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Employees;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Employees.Commands;
public sealed record UpdateEmployeeStatusCommand(
    int Id)
    : IRequest<Result<int>>;

internal sealed record UpdateEmployeeStatusCommandHandler(
    IEmployeeRepository _repository,
    IUnitOfWork _unitOfWork)
    : IRequestHandler<UpdateEmployeeStatusCommand, Result<int>>
{
    public async Task<Result<int>> Handle(UpdateEmployeeStatusCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var employee = await _repository.GetByIdAsync(request.Id);

            if (employee is null)
                return Result<int>.Fail("Data not found");

            employee.Status = !employee.Status;

            await _repository.UpdateAsync(employee);

            await _unitOfWork.Commit(cancellationToken);

            return Result<int>.Success(employee.Id);
        }
        catch (Exception ex)
        {
            return Result<int>.Fail(ex.Message);
        }
    }
}
