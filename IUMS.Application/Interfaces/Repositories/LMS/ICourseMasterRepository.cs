using IUMS.Domain.Entities.Academic;
using IUMS.Domain.Entities.LMS;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IUMS.Application.Interfaces.Repositories.LMS;
public interface ICourseMasterRepository
{
    IQueryable<CourseMaster> CourseMasters { get; }

    Task<List<CourseMaster>> GetListAsync();

    Task<CourseMaster> GetByIdAsync(int courseMasterId);

    Task<int> InsertAsync(CourseMaster courseMaster);

    Task UpdateAsync(CourseMaster courseMaster);

    Task DeleteAsync(CourseMaster courseMaster);
}
