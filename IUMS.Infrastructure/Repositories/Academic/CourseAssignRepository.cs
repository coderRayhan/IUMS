using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Academic;
using IUMS.Domain.Entities.Academic;
using IUMS.Infrastructure.CacheKeys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IUMS.Infrastructure.Repositories.Academic;
public class CourseAssignRepository : ICourseAssignRepository
{
    private readonly IRepositoryAsync<CourseAssign> _repository;
    private readonly IDistributedCache _distributedCache;

    public CourseAssignRepository(IRepositoryAsync<CourseAssign> repository, IDistributedCache distributedCache)
    {
        _repository = repository;
        _distributedCache = distributedCache;
    }

    public IQueryable<CourseAssign> CourseAssigns => _repository.Entities;

    public async Task DeleteAsync(CourseAssign courseAssign)
    {
        await _repository.DeleteAsync(courseAssign);
        await _distributedCache.RemoveAsync(CourseAssignCacheKeys.ListKey);
        await _distributedCache.RemoveAsync(CourseAssignCacheKeys.GetKey(courseAssign.Id));
    }

    public async Task<CourseAssign> GetByIdAsync(int id)
    {
        return await _repository.Entities.Where(ca => ca.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<CourseAssign>> GetListAsync()
    {
        return await _repository.Entities.ToListAsync();
    }

    public async Task<int> InsertAsync(CourseAssign courseAssign)
    {
        await _repository.AddAsync(courseAssign);
        await _distributedCache.RemoveAsync(CourseAssignCacheKeys.ListKey);
        return courseAssign.Id;
    }

    public async Task UpdateAsync(CourseAssign courseAssign)
    {
        await _repository.UpdateAsync(courseAssign);
        await _distributedCache.RemoveAsync(CourseAssignCacheKeys.ListKey);
        await _distributedCache.RemoveAsync(CourseAssignCacheKeys.GetKey(courseAssign.Id));
    }
}
