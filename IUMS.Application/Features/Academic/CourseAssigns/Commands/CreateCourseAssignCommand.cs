using AspNetCoreHero.Results;
using AutoMapper;
using IUMS.Application.Interfaces.Contexts;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Academic;
using IUMS.Domain.Entities.Academic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Academic.CourseAssigns.Commands;
public sealed record CreateCourseAssignCommand
    : IRequest<Result<int>>
{
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

internal sealed record CreateCourseAssignCommandHandler(
    ICourseAssignRepository _repository,
    IMapper _mapper,
    IUnitOfWork _unitOfWork,
    IDapperContext _dapper)
    : IRequestHandler<CreateCourseAssignCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateCourseAssignCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (await _dapper.IsExist("Aca_CourseAssigns", new string[] { "SessionId", "FacultyId", "DepartmentId", "ProgramId", "BatchId", "AcademicSemesterId", "CourseId" }, new { request.SessionId, request.FacultyId, request.DepartmentId, request.ProgramId, request.BatchId, request.AcademicSemesterId, request.CourseId }))
                return Result<int>.Fail("This course is already assigned");

            var courseAssign = _mapper.Map<CourseAssign>(request);

            await _repository.InsertAsync(courseAssign);

            await _unitOfWork.Commit(cancellationToken);

            return Result<int>.Success(courseAssign.Id);
        }
        catch (Exception ex)
        {
            return Result<int>.Fail(ex.Message);
        }
    }
}
