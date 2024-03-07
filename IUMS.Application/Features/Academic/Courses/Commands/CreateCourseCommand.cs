using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using IUMS.Application.Interfaces.Repositories.Academic;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Contexts;
using IUMS.Domain.Entities.Academic;

namespace IUMS.Application.Features.Academic.Courses.Commands;
public sealed record CreateCourseCommand : IRequest<Result<int>>
{
    public int ProgramId { get; set; }
    public string CourseCode { get; set; }
    public decimal CreditHour { get; set; }
    public decimal ConductHour { get; set; }
    public string CourseName { get; set; }
    public int CourseTypeId { get; set; }
    public bool IsActive { get; set; }
    public int TotalClass { get; set; }
}

internal sealed record CreateCourseCommandHandler(
    ICourseRepository CourseRepository,
    IMapper Mapper,
    IUnitOfWork UnitOfWork,
    IDapperContext _dapper)
    : IRequestHandler<CreateCourseCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        try
        {

            if (await _dapper.IsExist("Aca_Courses", new string[] { "CourseCode", "ProgramId" }, new { request.CourseCode, request.ProgramId }))
            {
                return Result<int>.Fail("Same Course Already Exits in this Program");
            }
            else
            {
                var entity = Mapper.Map<Course>(request);
                await CourseRepository.InsertAsync(entity);
                await UnitOfWork.Commit(cancellationToken);
                return Result<int>.Success();
            }
        }
        catch (Exception ex)
        {
            return Result<int>.Fail(ex.Message);
        }
    }
}
