using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.LMS;
using IUMS.Domain.Entities.LMS;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IUMS.Infrastructure.Repositories.LMS;
public class CourseMasterRepository : ICourseMasterRepository
{
    private readonly IRepositoryAsync<CourseMaster> _repository;
    public IQueryable<CourseMaster> CourseMasters => _repository.Entities;

    public async Task DeleteAsync(CourseMaster courseMaster)
    {
        await _repository.DeleteAsync(courseMaster);
    }

    public async Task<CourseMaster> GetByIdAsync(int courseMasterId)
    {
        return await _repository.Entities
            .Where(e => e.Id == courseMasterId)
            .Include(e => e.CourseChapters)
            .Include(e => e.CourseOutcomes)
            .Include( e => e.CourseFAQs)
            .FirstOrDefaultAsync();
    }

    public async Task<List<CourseMaster>> GetListAsync()
    {
        return await _repository.Entities
            .Include(e => e.CourseChapters)
            .Include(e => e.CourseOutcomes)
            .Include(e => e.CourseFAQs)
            .ToListAsync();
    }

    public async Task<int> InsertAsync(CourseMaster courseMaster)
    {
        await _repository.AddAsync(courseMaster);
        return courseMaster.Id;
    }

    public async Task UpdateAsync(CourseMaster courseMaster)
    {
        await _repository.UpdateAsync(courseMaster);
    }
}
