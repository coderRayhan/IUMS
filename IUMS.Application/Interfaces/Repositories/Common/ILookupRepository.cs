using IUMS.Domain.Entities.Academic;
using IUMS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUMS.Application.Interfaces.Repositories.Common;
public interface ILookupRepository
{
    IQueryable<Lookup> Lookups { get; }

    Task<List<Lookup>> GetListAsync();

    Task<Lookup> GetByIdAsync(int lookupId);

    Task<int> InsertAsync(Lookup lookup);

    Task UpdateAsync(Lookup lookup);

    Task DeleteAsync(Lookup lookup);
}
