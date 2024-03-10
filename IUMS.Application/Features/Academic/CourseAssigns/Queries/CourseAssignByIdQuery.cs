using AspNetCoreHero.Results;
using AutoMapper;
using IUMS.Application.Interfaces.Repositories.Academic;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Academic.CourseAssigns.Queries;
public sealed record CourseAssignByIdQuery(
    int Id)
    : IRequest<Result<CourseAssignResponse>>;

internal sealed record CourseAssignByIdQueryHandler(
    ICourseAssignRepository _repository,
    IMapper _mapper)
    : IRequestHandler<CourseAssignByIdQuery, Result<CourseAssignResponse>>
{
    public async Task<Result<CourseAssignResponse>> Handle(CourseAssignByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            if (entity is null)
                return Result<CourseAssignResponse>.Fail("Data not found");

            var mapped = _mapper.Map<CourseAssignResponse>(entity);

            return Result<CourseAssignResponse>.Success(mapped);
        }
        catch (Exception ex)
        {
            return Result<CourseAssignResponse>.Fail(ex.Message);
        }
    }
}
