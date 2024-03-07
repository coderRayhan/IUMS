using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Academic;
using IUMS.Domain.Entities.Academic;
using IUMS.Infrastructure.CacheKeys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IUMS.Infrastructure.Repositories.Academic;
public class CourseRepository : ICourseRepository
{
    private readonly IRepositoryAsync<Course> _repository;
    private readonly IDistributedCache _distributedCache;

    public CourseRepository(IDistributedCache distributedCache, IRepositoryAsync<Course> repository)
    {
        _distributedCache = distributedCache;
        _repository = repository;
    }
    public IQueryable<Course> Courses => _repository.Entities;

    public async Task DeleteAsync(Course course)
    {
        await _repository.DeleteAsync(course);
        await _distributedCache.RemoveAsync(CourseCacheKeys.ListKey);
        await _distributedCache.RefreshAsync(CourseCacheKeys.GetKey(course.Id));
    }

    public async Task<Course> GetByIdAsync(int courseId)
    {
        return await _repository.Entities
            .Where(c => c.Id == courseId)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Course>> GetListAsync()
    {
        return await _repository.Entities
            .ToListAsync();
    }

    public async Task<int> InsertAsync(Course course)
    {
        await _repository.AddAsync(course);
        await _distributedCache.RemoveAsync(CourseCacheKeys.ListKey);
        await _distributedCache.RemoveAsync(CourseCacheKeys.SelectListKey);
        return course.Id;
    }

    public async Task UpdateAsync(Course course)
    {
        await _repository.UpdateAsync(course);
        await _distributedCache.RemoveAsync(CourseCacheKeys.ListKey);
        await _distributedCache.RemoveAsync(CourseCacheKeys.SelectListKey);
        await _distributedCache.RemoveAsync(CourseCacheKeys.GetDetailsKey(course.Id));
    }
}
