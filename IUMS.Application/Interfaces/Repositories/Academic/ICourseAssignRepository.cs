using IUMS.Domain.Entities.Academic;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IUMS.Application.Interfaces.Repositories.Academic;
public interface ICourseAssignRepository
{
    IQueryable<CourseAssign> CourseAssigns { get; }

    Task<List<CourseAssign>> GetListAsync();

    Task<CourseAssign> GetByIdAsync(int id);

    Task<int> InsertAsync(CourseAssign courseAssign);

    Task UpdateAsync(CourseAssign courseAssign);

    Task DeleteAsync(CourseAssign courseAssign);
}
