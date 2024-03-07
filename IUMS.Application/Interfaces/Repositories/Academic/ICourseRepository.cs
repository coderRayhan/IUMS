using IUMS.Domain.Entities.Academic;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IUMS.Application.Interfaces.Repositories.Academic;
public interface ICourseRepository
{
    IQueryable<Course> Courses { get; }
    Task<List<Course>> GetListAsync();
    Task<Course> GetByIdAsync(int courseId);
    Task<int> InsertAsync(Course course);
    Task UpdateAsync(Course course);
    Task DeleteAsync(Course course);
}
