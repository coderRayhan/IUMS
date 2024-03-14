using AspNetCoreHero.Results;
using AutoMapper;
using IUMS.Application.Interfaces.Repositories.Employees;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Employees.Queries;
public sealed record EmployeeByIdQuery(
    int Id)
    : IRequest<Result<EmployeeResponse>>;

internal sealed record EmployeeByIdQueryHandler(
    IEmployeeRepository _repository,
    IMapper _mapper)
    : IRequestHandler<EmployeeByIdQuery, Result<EmployeeResponse>>
{
    public async Task<Result<EmployeeResponse>> Handle(EmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var employee = await _repository.GetByIdAsync(request.Id);

            if (employee is null)
                return Result<EmployeeResponse>.Fail("Data not found");

            var mappedResponse = _mapper.Map<EmployeeResponse>(employee);

            return Result<EmployeeResponse>.Success(mappedResponse);
        }
        catch (Exception ex)
        {
            return Result<EmployeeResponse>.Fail(ex.Message);
        }
    }
}
