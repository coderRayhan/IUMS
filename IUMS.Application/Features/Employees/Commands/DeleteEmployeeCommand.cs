using AspNetCoreHero.Results;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Employees;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Employees.Commands;
public sealed record DeleteEmployeeCommand(
	int Id)
    : IRequest<Result<int>>;

internal sealed record DeleteEmployeeCommandHandler(
	IEmployeeRepository _repository,
	IUnitOfWork _unitOfWork)
    : IRequestHandler<DeleteEmployeeCommand, Result<int>>
{
    public async Task<Result<int>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
		try
		{
			var employee = await _repository.GetByIdAsync(request.Id);

			if (employee is null)
				return Result<int>.Fail("Data not found");

			await _repository.DeleteAsync(employee);

			await _unitOfWork.Commit(cancellationToken);

			return Result<int>.Success();
        }
		catch (Exception ex)
		{
			return Result<int>.Fail(ex.Message);
		}
    }
}
