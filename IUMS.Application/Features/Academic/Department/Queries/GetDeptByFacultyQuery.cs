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

namespace IUMS.Application.Features.Academic.Department.Queries.GetFilteredDeptByFaculty
{
    public record GetDeptByFacultyQuery(int FacultyId) : IRequest<Result<List<GetDeptByFacultyResponse>>>{}
    public record GetDeptByFacultyQueryHandler(
        IDapperContext _context,
        IMapper _mapper) : IRequestHandler<GetDeptByFacultyQuery, Result<List<GetDeptByFacultyResponse>>>
    {
        public async Task<Result<List<GetDeptByFacultyResponse>>> Handle(GetDeptByFacultyQuery request, CancellationToken cancellationToken)
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
