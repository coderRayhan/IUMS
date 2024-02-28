using IUMS.Domain.Entities.Academic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUMS.Application.Interfaces.Repositories.Academic
{
    public interface IBatchRepository
    {
        IQueryable<Batch> Batches { get; }

        Task<List<Batch>> GetListAsync();

        Task<Batch> GetByIdAsync(int batchId);

        Task<int> InsertAsync(Batch batch);

        Task UpdateAsync(Batch batch);

        Task DeleteAsync(Batch batch);
    }
}
