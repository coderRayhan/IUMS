using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.LMS;
using MediatR;

namespace IUMS.Application.Features.LMS.CourseChapters.Commands
{
    public sealed record DeleteCourseChapterCommand(int Id) 
        : IRequest<Result<int>>;
    internal sealed record DeleteCourseChapterCommandHandler(
        ICourseChapterRepository _repository, 
        IChapterClassRepository _classRepo, 
        IUnitOfWork _unitOfWork) 
        : IRequestHandler<DeleteCourseChapterCommand, Result<int>>
    {
        public async Task<Result<int>> Handle(DeleteCourseChapterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(request.Id);
                if (entity == null)
                    return Result<int>.Fail("Data not found");
                else
                {
                    var classList = _classRepo.GetListAsync().Result.Where(e => e.CourseChapterId == request.Id).ToList();
                    if(classList.Count != 0)
                    {
                        return Result<int>.Fail("Delete is not allowed when child data exist");
                    }
                }
                await _repository.DeleteAsync(entity);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(0);
            }
            catch (Exception ex)
            {
                return Result<int>.Fail(ex.Message);
            }
        }
    }
}
