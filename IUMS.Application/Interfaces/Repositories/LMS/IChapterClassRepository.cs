using IUMS.Domain.Entities.Academic;
using IUMS.Domain.Entities.LMS;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IUMS.Application.Interfaces.Repositories.LMS;
public interface IChapterClassRepository
{
    IQueryable<ChapterClass> ChapterClasses { get; }

    Task<List<ChapterClass>> GetListAsync();

    Task<ChapterClass> GetByIdAsync(int chapterClassId);

    Task<int> InsertAsync(ChapterClass chapterClass);

    Task UpdateAsync(ChapterClass chapterClass);

    Task DeleteAsync(ChapterClass chapterClass);
}
