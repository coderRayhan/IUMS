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
public class TeacherAssignRepository : ITeacherAssignRepository
{
    private readonly IRepositoryAsync<TeacherAssign> _repository;
    private readonly IDistributedCache _distributedCache;
    public TeacherAssignRepository(IRepositoryAsync<TeacherAssign> repository, IDistributedCache distributedCache)
    {
        _repository = repository;
        _distributedCache = distributedCache;
    }

    public IQueryable<TeacherAssign> TeacherAssigns => _repository.Entities;

    public async Task DeleteAsync(TeacherAssign teacherAssign)
    {
        await _repository.DeleteAsync(teacherAssign);
        await _distributedCache.RemoveAsync(TeacherAssignCacheKeys.ListKey);
        await _distributedCache.RemoveAsync(TeacherAssignCacheKeys.GetKey(teacherAssign.Id));
    }

    public async Task<TeacherAssign> GetByIdAsync(int teacherAssignId)
    {
        return await _repository.Entities.Where(e => e.Id == teacherAssignId).FirstOrDefaultAsync();
    }

    public async Task<List<TeacherAssign>> GetListAsync()
    {
        return await _repository.Entities.ToListAsync();
    }

    public async Task<int> InsertAsync(TeacherAssign teacherAssign)
    {
        await _repository.AddAsync(teacherAssign);
        await _distributedCache.RemoveAsync(TeacherAssignCacheKeys.ListKey);
        await _distributedCache.RemoveAsync(TeacherAssignCacheKeys.SelectListKey);
        return teacherAssign.Id;
    }

    public async Task UpdateAsync(TeacherAssign teacherAssign)
    {
        await _repository.UpdateAsync(teacherAssign);
        await _distributedCache.RemoveAsync(TeacherAssignCacheKeys.ListKey);
        await _distributedCache.RemoveAsync(TeacherAssignCacheKeys.GetKey(teacherAssign.Id));
    }
}
