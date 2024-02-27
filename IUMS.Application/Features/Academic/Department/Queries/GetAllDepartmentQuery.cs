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
    public record GetAllDepartmentQuery : IRequest<Result<List<GetAllDepartmentResponse>>>;
    public record GetAllDepartmentQueryHandler(
        IDapperContext _context,
        IMapper _mapper) : IRequestHandler<GetAllDepartmentQuery, Result<List<GetAllDepartmentResponse>>>
    {
        public async Task<Result<List<GetAllDepartmentResponse>>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var query = QUERIES.GET_All_DEPARTMENT;

                IEnumerable<GetAllDepartmentResponse> departmentList;

                using (var connection = _context.CreateConnection())
                {
                    departmentList = await connection.QueryAsync<GetAllDepartmentResponse>(query);
                }

                var mappedDepartments = _mapper.Map<List<GetAllDepartmentResponse>>(departmentList);

                return Result<List<GetAllDepartmentResponse>>.Success(mappedDepartments);
            }
            catch (Exception ex)
            {
                return Result<List<GetAllDepartmentResponse>>.Fail(ex.Message);
            }       
        }
    }
}
