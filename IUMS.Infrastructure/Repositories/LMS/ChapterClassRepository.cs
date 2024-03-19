using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.LMS;
using IUMS.Domain.Entities.LMS;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IUMS.Infrastructure.Repositories.LMS;
public class ChapterClassRepository : IChapterClassRepository
{
    private readonly IRepositoryAsync<ChapterClass> _repository;

    public ChapterClassRepository(IRepositoryAsync<ChapterClass> repository)
    {
        _repository = repository;
    }

    public IQueryable<ChapterClass> ChapterClasses => _repository.Entities;

    public async Task DeleteAsync(ChapterClass chapterClass)
    {
        await _repository.DeleteAsync(chapterClass);
    }

    public async Task<ChapterClass> GetByIdAsync(int chapterClassId)
    {
        return await _repository.Entities.Where(e => e.Id == chapterClassId).FirstOrDefaultAsync();
    }

    public async Task<List<ChapterClass>> GetListAsync()
    {
        return await _repository.Entities.ToListAsync();
    }

    public async Task<int> InsertAsync(ChapterClass chapterClass)
    {
        await _repository.AddAsync(chapterClass);
        return chapterClass.Id;
    }

    public async Task UpdateAsync(ChapterClass chapterClass)
    {
        await _repository.UpdateAsync(chapterClass);
    }
}
