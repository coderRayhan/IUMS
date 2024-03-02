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
public class LookupRepository : ILookupRepository
{
    private readonly IRepositoryAsync<Lookup> _repository;
    private readonly IDistributedCache _distributedCache;

    public LookupRepository(IRepositoryAsync<Lookup> repository, IDistributedCache distributedCache)
    {
        _repository = repository;
        _distributedCache = distributedCache;
    }

    public IQueryable<Lookup> Lookups => _repository.Entities;

    public async Task DeleteAsync(Lookup lookup)
    {
        await _repository.DeleteAsync(lookup);
        await _distributedCache.RemoveAsync(LookupCacheKeys.ListKey);
        await _distributedCache.RemoveAsync(LookupCacheKeys.GetKey(lookup.Id));
    }

    public async Task<Lookup> GetByIdAsync(int lookupId)
    {
        return await _repository.Entities.Where(l => l.Id == lookupId).FirstOrDefaultAsync();
    }

    public async Task<List<Lookup>> GetListAsync()
    {
        return await _repository.Entities.ToListAsync();
    }

    public async Task<int> InsertAsync(Lookup lookup)
    {
        await _repository.AddAsync(lookup);
        await _distributedCache.RemoveAsync(LookupCacheKeys.ListKey);
        return lookup.Id;
    }

    public async Task UpdateAsync(Lookup lookup)
    {
        await _repository.UpdateAsync(lookup);
        await _distributedCache.RemoveAsync(LookupCacheKeys.ListKey);
        await _distributedCache.RemoveAsync(LookupCacheKeys.GetKey(lookup.Id));
    }
}
