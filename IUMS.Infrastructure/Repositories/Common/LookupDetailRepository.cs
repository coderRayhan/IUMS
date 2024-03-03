using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Common;
using IUMS.Domain.Entities.Common;
using IUMS.Infrastructure.CacheKeys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUMS.Infrastructure.Repositories.Common;
public class LookupDetailRepository : ILookupDetailRepository
{
    private readonly IRepositoryAsync<LookupDetail> _repository;
    private readonly IDistributedCache _distributedCache;

    public LookupDetailRepository(IRepositoryAsync<LookupDetail> repository, IDistributedCache distributedCache)
    {
        _repository = repository;
        _distributedCache = distributedCache;
    }

    public IQueryable<LookupDetail> LookupDetails => _repository.Entities;

    public async Task DeleteAsync(LookupDetail LookupDetail)
    {
        await _repository.DeleteAsync(LookupDetail);
        await _distributedCache.RemoveAsync(LookupDetailCacheKeys.ListKey);
        await _distributedCache.RemoveAsync(LookupDetailCacheKeys.GetKey(LookupDetail.Id));
    }

    public async Task<LookupDetail> GetByIdAsync(int LookupDetailId)
    {
        return await _repository.Entities.Where(l => l.Id == LookupDetailId).FirstOrDefaultAsync();
    }

    public async Task<List<LookupDetail>> GetListAsync()
    {
        return await _repository.Entities.ToListAsync();
    }

    public async Task<int> InsertAsync(LookupDetail LookupDetail)
    {
        await _repository.AddAsync(LookupDetail);
        await _distributedCache.RemoveAsync(LookupDetailCacheKeys.ListKey);
        return LookupDetail.Id;
    }

    public async Task UpdateAsync(LookupDetail LookupDetail)
    {
        await _repository.UpdateAsync(LookupDetail);
        await _distributedCache.RemoveAsync(LookupDetailCacheKeys.ListKey);
        await _distributedCache.RemoveAsync(LookupDetailCacheKeys.GetKey(LookupDetail.Id));
    }
}
