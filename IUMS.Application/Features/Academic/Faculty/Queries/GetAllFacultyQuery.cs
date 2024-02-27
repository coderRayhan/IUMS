using AspNetCoreHero.Results;
using AutoMapper;
using Dapper;
using IUMS.Application.Features.Academic.Faculty.Queries;
using IUMS.Application.Interfaces.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static IUMS.Application.Constants.DBConstants;

namespace UEMS.Application.Features.Academic.Faculty.Queries.GetAll
{
    public record GetAllFacultyQuery : IRequest<Result<List<FacultyResponse>>>
    {
        public record GetAllFacultyQueryHandler (IDapperContext _context, IMapper _mapper) : IRequestHandler<GetAllFacultyQuery, Result<List<FacultyResponse>>>
        {
            public async Task<Result<List<FacultyResponse>>> Handle(GetAllFacultyQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var query = QUERIES.GET_All_FACULTY;

                    IEnumerable<FacultyResponse> facultyList;

                    using (var connection = _context.CreateConnection())
                    {
                        facultyList = await connection.QueryAsync<FacultyResponse>(query);
                    }

                    return Result<List<FacultyResponse>>.Success(_mapper.Map<List<FacultyResponse>>(facultyList));
                }
                catch (Exception ex)
                {
                    return Result<List<FacultyResponse>>.Fail(ex.Message);
                }
            }
        }
    }
}