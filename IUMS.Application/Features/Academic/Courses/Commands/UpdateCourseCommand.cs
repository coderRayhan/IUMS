using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using IUMS.Application.Interfaces.Repositories.Academic;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Contexts;

namespace IUMS.Application.Features.Academic.Courses.Commands;
public sealed record UpdateCourseCommand : IRequest<Result<int>>
{
    public int Id { get; set; }
    public int ProgramId { get; set; }
    public string CourseCode { get; set; }
    public decimal CreditHour { get; set; }
    public decimal ConductHour { get; set; }
    public string CourseName { get; set; }
    public int CourseTypeId { get; set; }
    public bool IsActive { get; set; }
    public int TotalClass { get; set; }
}

internal sealed record UpdateCourseCommandHandler(
    ICourseRepository _repository,
    IUnitOfWork _unitOfWork,
    IDapperContext _dapper)
    : IRequestHandler<UpdateCourseCommand, Result<int>>
{
    public async Task<Result<int>> Handle(UpdateCourseCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var course = await _repository.GetByIdAsync(command.Id);
            if (course == null)
            {
                return Result<int>.Fail($"Course Not Found.");
            }
            else
            {
                //if (await _dapper.IsExist("Aca_Courses", new string[] { "CourseCode", "ProgramId" }, new { command.CourseCode, command.ProgramId }))
                //{
                //    return Result<int>.Fail("Same Course Already Exits in this Program");
                //}

                course.ProgramId = command.ProgramId;
                course.CourseCode = command.CourseCode;
                course.CreditHour = command.CreditHour;
                course.ConductHour = command.ConductHour;
                course.CourseName = command.CourseName;
                course.CourseTypeId = command.CourseTypeId;
                course.IsActive = command.IsActive;
                course.TotalClass = command.TotalClass;

                await _repository.UpdateAsync(course);

                await _unitOfWork.Commit(cancellationToken);

                return Result<int>.Success(course.Id);
            }
        }
        catch (Exception ex)
        {
            return Result<int>.Fail(ex.Message);
        }
    }
}

