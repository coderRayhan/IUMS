using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.LMS;
using IUMS.Domain.Entities.LMS;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IUMS.Infrastructure.Repositories.LMS;
public class CourseChapterRepository : ICourseChapterRepository
{
    private readonly IRepositoryAsync<CourseChapter> _repository;

    public CourseChapterRepository(IRepositoryAsync<CourseChapter> repository)
    {
        _repository = repository;
    }

    public IQueryable<CourseChapter> CourseChapters => throw new System.NotImplementedException();

    public async Task DeleteAsync(CourseChapter courseChapter)
    {
        await _repository.DeleteAsync(courseChapter);
    }

    public async Task<CourseChapter> GetByIdAsync(int courseChapterId)
    {
        return await _repository.Entities.Where(e => e.Id == courseChapterId).Include(e => e.ChapterClasses).FirstOrDefaultAsync();
    }

    public async Task<List<CourseChapter>> GetListAsync()
    {
        return await _repository.Entities.Include(e => e.ChapterClasses).ToListAsync();
    }

    public async Task<int> InsertAsync(CourseChapter courseChapter)
    {
        await _repository.AddAsync(courseChapter);
        return courseChapter.Id;
    }

    public async Task UpdateAsync(CourseChapter courseChapter)
    {
        await _repository.UpdateAsync(courseChapter);
    }
}
