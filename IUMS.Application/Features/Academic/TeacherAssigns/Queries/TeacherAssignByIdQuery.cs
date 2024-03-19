using AspNetCoreHero.Results;
using AutoMapper;
using IUMS.Application.Interfaces.Repositories.Academic;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Academic.TeacherAssigns.Queries;
public sealed record TeacherAssignByIdQuery(
    int Id)
    : IRequest<Result<TeacherAssignResponse>>;

internal sealed record TeacherAssignByIdQueryHandler(
    ITeacherAssignRepository _repository,
    IMapper _mapper)
    : IRequestHandler<TeacherAssignByIdQuery, Result<TeacherAssignResponse>>
{
    public async Task<Result<TeacherAssignResponse>> Handle(TeacherAssignByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            if (entity is null)
                return Result<TeacherAssignResponse>.Fail("Data not found");

            var response = _mapper.Map<TeacherAssignResponse>(entity);

            return Result<TeacherAssignResponse>.Success(response);
        }
        catch (Exception ex)
        {
            return Result<TeacherAssignResponse>.Fail(ex.Message);
        }
    }
}
