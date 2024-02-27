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
    public record GetDepartmentByIdQuery : IRequest<Result<GetAllDepartmentResponse>>
    {
        public int Id { get; set; }

        public record GetDepartmentByIdQueryHandler(
            IDepartmentRepository Repository, 
            IMapper Mapper) 
            : IRequestHandler<GetDepartmentByIdQuery, Result<GetAllDepartmentResponse>>
        {
            public async Task<Result<GetAllDepartmentResponse>> Handle(GetDepartmentByIdQuery query, CancellationToken cancellationToken)
            {
                try
                {
                    var department = await Repository.GetByIdAsync(query.Id);
                    var mappedDepartment = Mapper.Map<GetAllDepartmentResponse>(department);
                    return Result<GetAllDepartmentResponse>.Success(mappedDepartment);
                }
                catch (Exception ex)
                {
                    return Result<GetAllDepartmentResponse>.Fail(ex.Message);
                }
            }
        }
    }
}
