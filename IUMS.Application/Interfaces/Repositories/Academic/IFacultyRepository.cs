using IUMS.Domain.Entities.Academic;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IUMS.Application.Interfaces.Repositories.Academic
{
    public interface IFacultyRepository
    {
        IQueryable<Faculty> Faculties { get; }

        Task<List<Faculty>> GetListAsync();

        Task<Faculty> GetByIdAsync(int FacultyId);

        Task<int> InsertAsync(Faculty Faculty);

        Task UpdateAsync(Faculty Faculty);

        Task DeleteAsync(Faculty Faculty);
    }
}
