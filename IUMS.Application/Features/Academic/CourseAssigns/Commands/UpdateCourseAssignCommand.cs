using AspNetCoreHero.Results;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Academic;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Academic.CourseAssigns.Commands;
public sealed record UpdateCourseAssignCommand 
    :IRequest<Result<int>>
{
    public int Id { get; set; }
    public int SessionId { get; set; }
    public int FacultyId { get; set; }
    public int DepartmentId { get; set; }
    public int ProgramId { get; set; }
    //public int SemesterId { get; set; }
    public int AcademicSemesterId { get; set; }
    public int CourseId { get; set; }
    public double TotalMarks { get; set; }
    public decimal ContinuousAssesment { get; set; }
    public decimal TermFinal { get; set; }
    public decimal PassMark { get; set; }
    public int BatchId { get; set; }
}

internal sealed record UpdateCourseAssignCommandHandler(
    ICourseAssignRepository _repository,
    IUnitOfWork _unitOfWork)
    : IRequestHandler<UpdateCourseAssignCommand, Result<int>>
{
    public async Task<Result<int>> Handle(UpdateCourseAssignCommand request, CancellationToken cancellationToken)
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
            entity.AcademicSemesterId = request.AcademicSemesterId;
            entity.CourseId = request.CourseId;
            entity.TotalMarks = request.TotalMarks;
            entity.ContinuousAssesment = request.ContinuousAssesment;
            entity.TermFinal = request.TermFinal;
            entity.PassMark = request.PassMark;
            entity.BatchId = request.BatchId;

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
