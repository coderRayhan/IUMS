using AspNetCoreHero.Results;
using AutoMapper;
using IUMS.Application.Features.Academic.Faculty.Queries;
using IUMS.Application.Interfaces.Repositories.Academic;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace UEMS.Application.Features.Academic.Faculty.Queries
{
    public record GetFacultyByIdQuery : IRequest<Result<FacultyResponse>>
    {
        public int Id { get; set; }

        public record GetFacultyByIdQueryHandler(IFacultyRepository FacultyRepository, IMapper Mapper) : IRequestHandler<GetFacultyByIdQuery, Result<FacultyResponse>>
        {
            public async Task<Result<FacultyResponse>> Handle(GetFacultyByIdQuery query, CancellationToken cancellationToken)
            {
                try
                {
                    var faculty = await FacultyRepository.GetByIdAsync(query.Id);
                    var mappedFaculty = Mapper.Map<FacultyResponse>(faculty);
                    return Result<FacultyResponse>.Success(mappedFaculty);
                }
                catch (Exception ex)
                {
                    return Result<FacultyResponse>.Fail(ex.Message);
                }              
            }
        }
    }
}
