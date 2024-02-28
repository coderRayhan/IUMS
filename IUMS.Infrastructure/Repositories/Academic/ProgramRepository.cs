using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Academic;
using IUMS.Domain.Entities.Academic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IUMS.Infrastructure.Repositories.Academic
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly IRepositoryAsync<Program> _repository;
        private readonly IDistributedCache _distributedCache;

        public ProgramRepository(IDistributedCache distributedCache, IRepositoryAsync<Program> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }


        public IQueryable<Program> Programs => _repository.Entities;

        public async Task DeleteAsync(Program Program)
        {
            await _repository.DeleteAsync(Program);
            await _distributedCache.RemoveAsync(CacheKeys.ProgramCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.ProgramCacheKeys.GetKey(Program.Id));
        }

        public async Task<Program> GetByIdAsync(int ProgramId)
        {
            return await _repository.Entities.Where(p => p.Id == ProgramId).FirstOrDefaultAsync();
        }

        public async Task<List<Program>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public Task<List<Program>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> InsertAsync(Program Program)
        {
            await _repository.AddAsync(Program);
            await _distributedCache.RemoveAsync(CacheKeys.ProgramCacheKeys.ListKey);
            return Program.Id;
        }

        public async Task UpdateAsync(Program Program)
        {
            await _repository.UpdateAsync(Program);
            await _distributedCache.RemoveAsync(CacheKeys.ProgramCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.ProgramCacheKeys.GetKey(Program.Id));
        }
    }
}
