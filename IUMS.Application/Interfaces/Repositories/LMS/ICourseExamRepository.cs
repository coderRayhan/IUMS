using IUMS.Domain.Entities.Academic;
using IUMS.Domain.Entities.LMS;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IUMS.Application.Interfaces.Repositories.LMS;
public interface ICourseExamRepository
{
    IQueryable<CourseExam> CourseExams { get; }

    Task<List<CourseExam>> GetListAsync();

    Task<CourseExam> GetByIdAsync(int courseExamId);

    Task<int> InsertAsync(CourseExam courseExam);

    Task UpdateAsync(CourseExam courseExam);

    Task DeleteAsync(CourseExam courseExam);
}
