using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Student;
using IUMS.Domain.Entities.Student;
using IUMS.Infrastructure.CacheKeys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IUMS.Infrastructure.Repositories.Student;
public class StudentBasicInfoRepository : IStudentBasicInfoRepository
{
    private readonly IRepositoryAsync<StudentBasicInfo> _repository;
    private readonly IDistributedCache _distributedCache;

    public StudentBasicInfoRepository(IRepositoryAsync<StudentBasicInfo> repository, IDistributedCache distributedCache)
    {
        _repository = repository;
        _distributedCache = distributedCache;
    }
    public IQueryable<StudentBasicInfo> StudentBasicInfos => _repository.Entities;

    public async Task DeleteAsync(StudentBasicInfo studentBasicInfo)
    {
        await _repository.DeleteAsync(studentBasicInfo);
        await _distributedCache.RemoveAsync(StudentBasicInfoCacheKeys.ListKey);
        await _distributedCache.RemoveAsync(StudentBasicInfoCacheKeys.GetKey(studentBasicInfo.Id));
    }

    public async Task<StudentBasicInfo> GetByIdAsync(int studentId)
    {
        return await _repository.Entities.Where(l => l.Id == studentId).Include(e => e.StudentEducationalInfos).FirstOrDefaultAsync();
    }

    public async Task<List<StudentBasicInfo>> GetListAsync()
    {
        return await _repository.Entities.ToListAsync();
    }

    public async Task<int> InsertAsync(StudentBasicInfo studentBasicInfo)
    {
        await _repository.AddAsync(studentBasicInfo);
        await _distributedCache.RemoveAsync(StudentBasicInfoCacheKeys.ListKey);
        return studentBasicInfo.Id;
    }

    public async Task UpdateAsync(StudentBasicInfo studentBasicInfo)
    {
        await _repository.UpdateAsync(studentBasicInfo);
        await _distributedCache.RemoveAsync(StudentBasicInfoCacheKeys.ListKey);
        await _distributedCache.RemoveAsync(StudentBasicInfoCacheKeys.GetKey(studentBasicInfo.Id));
    }
}
