using AspNetCoreHero.Results;
using AutoMapper;
using IUMS.Application.Features.LMS.CourseQuestions.Queries;
using IUMS.Application.Interfaces.Repositories.LMS;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Domain.Entities.LMS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.LMS.CourseQuestions.Commands;
public sealed class CreateCourseQuestionCommand 
    :IRequest<Result<int>>
{
    public int CourseMasterId { get; set; }
    public int? CourseChapterId { get; set; }
    public int QuestionTypeId { get; set; }
    public bool IsWritten { get; set; }
    public string Question { get; set; }
    public decimal Mark { get; set; }
    public string Answer { get; set; }
    public bool IsChaperQuestion { get; set; }
    public List<QuestionOptionResponse> QuestionOptions { get; set; } = new();
}

internal sealed record CreateCourseQuestionCommandHandler(ICourseQuestionRepository Repository
                                                    , IMapper Mapper,
                                                     IUnitOfWork UnitOfWork) : IRequestHandler<CreateCourseQuestionCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateCourseQuestionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var mappedEntity = Mapper.Map<CourseQuestion>(request);
            mappedEntity.QuestionOptions = Mapper.Map<List<QuestionOption>>(request.QuestionOptions);
            await Repository.InsertAsync(mappedEntity);
            await UnitOfWork.Commit(cancellationToken);
            return Result<int>.Success(0);
        }
        catch (Exception ex)
        {
            return Result<int>.Fail(ex.Message);
        }
    }
}
