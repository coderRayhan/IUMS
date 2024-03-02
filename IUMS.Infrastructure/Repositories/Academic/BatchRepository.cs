using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Academic;
using IUMS.Domain.Entities.Academic;
using IUMS.Infrastructure.CacheKeys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUMS.Infrastructure.Repositories.Academic
{
    public class BatchRepository : IBatchRepository
    {
        private readonly IRepositoryAsync<Batch> _repository;
        private readonly IDistributedCache _distributedCache;

        public BatchRepository(IDistributedCache distributedCache, IRepositoryAsync<Batch> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }


        public IQueryable<Batch> Batches => _repository.Entities;

        public async Task DeleteAsync(Batch batch)
        {
            await _repository.DeleteAsync(batch);
            await _distributedCache.RemoveAsync(BatchCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(BatchCacheKeys.GetKey(batch.Id));
        }

        public async Task<Batch> GetByIdAsync(int batchId)
        {
            return await _repository.Entities.Where(p => p.Id == batchId).FirstOrDefaultAsync();
        }

        public async Task<List<Batch>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public Task<List<Batch>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> InsertAsync(Batch batch)
        {
            await _repository.AddAsync(batch);
            await _distributedCache.RemoveAsync(BatchCacheKeys.ListKey);
            return batch.Id;
        }

        public async Task UpdateAsync(Batch batch)
        {
            await _repository.UpdateAsync(batch);
            await _distributedCache.RemoveAsync(BatchCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(BatchCacheKeys.GetKey(batch.Id));
        }
    }
}
