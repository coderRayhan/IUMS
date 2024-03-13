using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Employees;
using IUMS.Domain.Entities.Academic;
using IUMS.Domain.Entities.Employees;
using IUMS.Infrastructure.CacheKeys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IUMS.Infrastructure.Repositories.Employees;
public class EmployeeRepository : IEmployeeRepository
{
    private readonly IRepositoryAsync<Employee> _repository;
    private readonly IDistributedCache _distributedCache;

    public EmployeeRepository(IRepositoryAsync<Employee> repository, IDistributedCache distributedCache)
    {
        _repository = repository;
        _distributedCache = distributedCache;
    }

    public IQueryable<Employee> Employees => _repository.Entities;

    public async Task DeleteAsync(Employee employee)
    {
        await _repository.DeleteAsync(employee);
        await _distributedCache.RemoveAsync(EmployeeCacheKeys.ListKey);
        await _distributedCache.RemoveAsync(EmployeeCacheKeys.GetKey(employee.Id));
    }

    public async Task<Employee> GetByIdAsync(int employeeId)
    {
        return await _repository.Entities.Where(e => e.Id == employeeId).FirstOrDefaultAsync();
    }

    public async Task<List<Employee>> GetListAsync()
    {
        return await _repository.Entities.ToListAsync();
    }

    public async Task<int> InsertAsync(Employee employee)
    {
        await _repository.AddAsync(employee);
        await _distributedCache.RemoveAsync(EmployeeCacheKeys.ListKey);
        return employee.Id;
    }

    public async Task UpdateAsync(Employee employee)
    {
        await _repository.UpdateAsync(employee);
        await _distributedCache.RemoveAsync(EmployeeCacheKeys.ListKey);
        await _distributedCache.RemoveAsync(EmployeeCacheKeys.GetKey(employee.Id));
    }
}
