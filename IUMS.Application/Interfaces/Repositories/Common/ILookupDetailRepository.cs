using IUMS.Domain.Entities.Academic;
using IUMS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUMS.Application.Interfaces.Repositories.Common;
public interface ILookupDetailRepository
{
    IQueryable<LookupDetail> LookupDetails { get; }

    Task<List<LookupDetail>> GetListAsync();

    Task<LookupDetail> GetByIdAsync(int lookupDetailId);

    Task<int> InsertAsync(LookupDetail lookupDetail);

    Task UpdateAsync(LookupDetail lookupDetail);

    Task DeleteAsync(LookupDetail lookupDetail);
}
