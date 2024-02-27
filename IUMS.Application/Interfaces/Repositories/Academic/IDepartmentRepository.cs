using IUMS.Domain.Entities.Academic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUMS.Application.Interfaces.Repositories.Academic
{
    public interface IDepartmentRepository
    {
        IQueryable<Department> Departments { get; }

        Task<List<Department>> GetListAsync();

        Task<Department> GetByIdAsync(int departmentId);

        Task<int> InsertAsync(Department department);

        Task UpdateAsync(Department department);

        Task DeleteAsync(Department department);
    }
}
