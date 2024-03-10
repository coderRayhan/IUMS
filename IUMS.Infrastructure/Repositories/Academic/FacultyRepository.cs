using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Academic;
using IUMS.Domain.Entities.Academic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IUMS.Infrastructure.Repositories.Academic
{
    public class FacultyRepository : IFacultyRepository
    {
        private readonly IRepositoryAsync<Faculty> _repository;
        private readonly IDistributedCache _distributedCache;

        public FacultyRepository(IDistributedCache distributedCache, IRepositoryAsync<Faculty> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }

        public IQueryable<Faculty> Faculties => _repository.Entities;

        public async Task DeleteAsync(Faculty faculty)
        {
            await _repository.DeleteAsync(faculty);
            await _distributedCache.RemoveAsync(CacheKeys.FacultyCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.FacultyCacheKeys.GetKey(faculty.Id));
        }

        public async Task<Faculty> GetByIdAsync(int facultyId)
        {
            return await _repository.Entities.Where(p => p.Id == facultyId).FirstOrDefaultAsync();
        }

        public async Task<List<Faculty>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public Task<List<Faculty>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> InsertAsync(Faculty faculty)
        {
            await _repository.AddAsync(faculty);
            await _distributedCache.RemoveAsync(CacheKeys.FacultyCacheKeys.ListKey);
            return faculty.Id;
        }

        public async Task UpdateAsync(Faculty faculty)
        {
            await _repository.UpdateAsync(faculty);
            await _distributedCache.RemoveAsync(CacheKeys.FacultyCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.FacultyCacheKeys.GetKey(faculty.Id));
        }
    }
}
