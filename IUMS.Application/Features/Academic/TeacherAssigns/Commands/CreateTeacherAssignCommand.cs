using AspNetCoreHero.Results;
using AutoMapper;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Academic;
using IUMS.Domain.Entities.Academic;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Academic.TeacherAssigns.Commands;
public sealed record CreateTeacherAssignCommand
    : IRequest<Result<int>>
{
    public int SessionId { get; set; }
    public int FacultyId { get; set; }
    public int DepartmentId { get; set; }
    public int ProgramId { get; set; }
    public int BatchId { get; set; }
    public int CourseId { get; set; }
    public int TeacherId { get; set; }
    public int AcademicSemesterId { get; set; }
}

internal sealed record CreateTeacherAssignCommandHandler(
    ITeacherAssignRepository _repository,
    IMapper _mapper,
    IUnitOfWork _unitOfWork)
    : IRequestHandler<CreateTeacherAssignCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateTeacherAssignCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<TeacherAssign>(request);

            await _repository.InsertAsync(entity);

            await _unitOfWork.Commit(cancellationToken);

            return Result<int>.Success();
        }
        catch (Exception ex)
        {
            return Result<int>.Fail(ex.Message);
        }
    }
}