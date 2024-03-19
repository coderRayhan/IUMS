using AspNetCoreHero.Results;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Academic;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Academic.TeacherAssigns.Commands;
public sealed record UpdateTeacherAssignCommand 
    : IRequest<Result<int>>
{
    public int Id { get; set; }
    public int SessionId { get; set; }
    public int FacultyId { get; set; }
    public int DepartmentId { get; set; }
    public int ProgramId { get; set; }
    public int BatchId { get; set; }
    public int CourseId { get; set; }
    public int TeacherId { get; set; }
    public int AcademicSemesterId { get; set; }
}

internal sealed record UpdateTeacherAssignCommandHandler(
    ITeacherAssignRepository _repository,
    IUnitOfWork _unitOfWork)
    : IRequestHandler<UpdateTeacherAssignCommand, Result<int>>
{
    public async Task<Result<int>> Handle(UpdateTeacherAssignCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            if (entity is null)
                return Result<int>.Fail("Data not found");

            entity.SessionId = request.SessionId;
            entity.FacultyId = request.FacultyId;
            entity.DepartmentId = request.DepartmentId;
            entity.ProgramId = request.ProgramId;
            entity.BatchId = request.BatchId;
            entity.CourseId = request.CourseId;
            entity.TeacherId = request.TeacherId;
            entity.AcademicSemesterId = request.AcademicSemesterId;

            await _repository.UpdateAsync(entity);

            await _unitOfWork.Commit(cancellationToken);

            return Result<int>.Success(entity.Id);
        }
        catch (Exception ex)
        {
            return Result<int>.Fail(ex.Message);
        }
    }
}
