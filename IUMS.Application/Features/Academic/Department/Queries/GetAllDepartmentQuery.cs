using AspNetCoreHero.Results;
using AutoMapper;
using Dapper;
using IUMS.Application.Features.Academic.Department.Queries;
using IUMS.Application.Interfaces.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static IUMS.Application.Constants.DBConstants;

namespace UEMS.Application.Features.Academic.Department.Queries.GetAll
{
    public record GetAllDepartmentQuery : IRequest<Result<List<DepartmentResponse>>>;
    public record GetAllDepartmentQueryHandler(
        IDapperContext _context,
        IMapper _mapper) : IRequestHandler<GetAllDepartmentQuery, Result<List<DepartmentResponse>>>
    {
        public async Task<Result<List<DepartmentResponse>>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var query = QUERIES.GET_All_DEPARTMENT;

                IEnumerable<DepartmentResponse> departmentList;

                using (var connection = _context.CreateConnection())
                {
                    departmentList = await connection.QueryAsync<DepartmentResponse>(query);
                }

                var mappedDepartments = _mapper.Map<List<DepartmentResponse>>(departmentList);

                return Result<List<DepartmentResponse>>.Success(mappedDepartments);
            }
            catch (Exception ex)
            {
                return Result<List<DepartmentResponse>>.Fail(ex.Message);
            }       
        }
    }
}
