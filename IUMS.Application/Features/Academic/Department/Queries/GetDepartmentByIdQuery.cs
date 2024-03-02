using AspNetCoreHero.Results;
using AutoMapper;
using IUMS.Application.Features.Academic.Department.Queries;
using IUMS.Application.Interfaces.Repositories.Academic;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace UEMS.Application.Features.Academic.Department.Queries
{
    public record GetDepartmentByIdQuery : IRequest<Result<DepartmentResponse>>
    {
        public int Id { get; set; }

        public record GetDepartmentByIdQueryHandler(
            IDepartmentRepository Repository, 
            IMapper Mapper) 
            : IRequestHandler<GetDepartmentByIdQuery, Result<DepartmentResponse>>
        {
            public async Task<Result<DepartmentResponse>> Handle(GetDepartmentByIdQuery query, CancellationToken cancellationToken)
            {
                try
                {
                    var department = await Repository.GetByIdAsync(query.Id);
                    var mappedDepartment = Mapper.Map<DepartmentResponse>(department);
                    return Result<DepartmentResponse>.Success(mappedDepartment);
                }
                catch (Exception ex)
                {
                    return Result<DepartmentResponse>.Fail(ex.Message);
                }
            }
        }
    }
}
