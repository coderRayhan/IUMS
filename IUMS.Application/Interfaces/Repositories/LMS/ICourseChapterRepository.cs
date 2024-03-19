using IUMS.Domain.Entities.Academic;
using IUMS.Domain.Entities.LMS;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IUMS.Application.Interfaces.Repositories.LMS;
public interface ICourseChapterRepository
{
    IQueryable<CourseChapter> CourseChapters { get; }

    Task<List<CourseChapter>> GetListAsync();

    Task<CourseChapter> GetByIdAsync(int courseChapterId);

    Task<int> InsertAsync(CourseChapter courseChapter);

    Task UpdateAsync(CourseChapter courseChapter);

    Task DeleteAsync(CourseChapter courseChapter);
}
