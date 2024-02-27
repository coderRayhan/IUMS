using AspNetCoreHero.Results;
using AutoMapper;
using Dapper;
using IUMS.Application.Features.Academic;
using IUMS.Application.Features.Academic.Department.Queries;
using IUMS.Application.Interfaces.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static IUMS.Application.Constants.DBConstants;

namespace IUMS.Application.Features.Academic.Department.Queries.GetFilteredDeptByFaculty
{
    public record GetDeptByFacultyForDropdownQuery(int FacultyId) : IRequest<Result<List<GetDeptByFacultyResponse>>>{}
    public class GetDeptByFacultyForDropdownQueryHandler : IRequestHandler<GetDeptByFacultyForDropdownQuery, Result<List<GetDeptByFacultyResponse>>>
    {
        private readonly IDapperContext _context;
        private readonly IMapper _mapper;

        public GetDeptByFacultyForDropdownQueryHandler(
            IDapperContext context, 
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<List<GetDeptByFacultyResponse>>> Handle(GetDeptByFacultyForDropdownQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var sql = QUERIES.GET_DEPT_BY_FACULTY_FOR_DROPDOWN;

                using var connection = _context.CreateConnection();

                var departments = await connection.QueryAsync<GetDeptByFacultyResponse>(sql, new { request.FacultyId });

                var mappedDepartments = _mapper.Map<List<GetDeptByFacultyResponse>>(departments);

                return Result<List<GetDeptByFacultyResponse>>.Success(mappedDepartments);
            }
            catch (Exception ex)
            {
                return Result<List<GetDeptByFacultyResponse>>.Fail(ex.Message);
            }          
        }
    }
}
