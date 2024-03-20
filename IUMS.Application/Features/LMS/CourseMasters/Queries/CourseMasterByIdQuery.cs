using System;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using AutoMapper;
using IUMS.Application.Interfaces.Repositories.LMS;
using MediatR;

namespace IUMS.Application.Features.LMS.CourseMasters.Queries
{
    public record CourseMasterByIdQuery(int Id) : IRequest<Result<CourseMasterResponse>> { }
    public record CourseMasterByIdQueryHandler(
        ICourseMasterRepository _repository, IMapper _mapper) 
        : IRequestHandler<CourseMasterByIdQuery, Result<CourseMasterResponse>>
    {
        public async Task<Result<CourseMasterResponse>> Handle(CourseMasterByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _repository.GetByIdAsync(request.Id);
                if(data == null)
                {
                    return Result<CourseMasterResponse>.Fail("Data not found");
                }
                var mappedData = _mapper.Map<CourseMasterResponse>(data);
                return Result<CourseMasterResponse>.Success(mappedData);
            }
            catch (Exception ex)
            {
                return Result<CourseMasterResponse>.Fail(ex.Message);
            }
        }
    }
}
