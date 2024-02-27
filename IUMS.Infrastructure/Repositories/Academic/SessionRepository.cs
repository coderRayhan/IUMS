using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using AspNetCoreHero.Boilerplate.Domain.Entities.Catalog;
using IUMS.Application.Interfaces.Repositories.Academic;
using IUMS.Domain.Entities.Academic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Infrastructure.Repositories.Academic
{
    public class SessionRepository : ISessionRepository
    {
        private readonly IRepositoryAsync<Session> _repository;
        private readonly IDistributedCache _distributedCache;

        public SessionRepository(IDistributedCache distributedCache, IRepositoryAsync<Session> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }

        public IQueryable<Session> Sessions => _repository.Entities;

		public IQueryable<Session> Entities => throw new System.NotImplementedException();

		public async Task DeleteAsync(Session Session)
        {
            await _repository.DeleteAsync(Session);
            await _distributedCache.RemoveAsync(CacheKeys.SessionCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.SessionCacheKeys.GetKey(Session.Id));
        }

		public async Task<Session> GetByIdAsync(int SessionId)
        {
            return await _repository.Entities.Where(p => p.Id == SessionId).FirstOrDefaultAsync();
        }

        public async Task<List<Session>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

		public Task<List<Session>> GetPagedReponseAsync(int pageNumber, int pageSize)
		{
			throw new System.NotImplementedException();
		}

		public async Task<int> InsertAsync(Session Session)
        {
            await _repository.AddAsync(Session);
            await _distributedCache.RemoveAsync(CacheKeys.SessionCacheKeys.ListKey);
            return Session.Id;
        }

        public async Task UpdateAsync(Session Session)
        {
            await _repository.UpdateAsync(Session);
            await _distributedCache.RemoveAsync(CacheKeys.SessionCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.SessionCacheKeys.GetKey(Session.Id));
        }
    }
}