using IUMS.Domain.Entities.Employees;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IUMS.Application.Interfaces.Repositories.Employees;
public interface IEmployeeRepository
{
    IQueryable<Employee> Employees { get; }

    Task<List<Employee>> GetListAsync();

    Task<Employee> GetByIdAsync(int employeeId);

    Task<int> InsertAsync(Employee employee);

    Task UpdateAsync(Employee employee);

    Task DeleteAsync(Employee employee);
}
