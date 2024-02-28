using IUMS.Domain.Entities.Academic;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IUMS.Application.Interfaces.Repositories.Academic
{
    public interface IProgramRepository
    {
        IQueryable<Program> Programs { get; }

        Task<List<Program>> GetListAsync();

        Task<Program> GetByIdAsync(int ProgramId);

        Task<int> InsertAsync(Program Program);

        Task UpdateAsync(Program Program);

        Task DeleteAsync(Program Program);
    }
}
