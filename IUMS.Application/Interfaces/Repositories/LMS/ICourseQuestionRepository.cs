using IUMS.Domain.Entities.Academic;
using IUMS.Domain.Entities.LMS;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IUMS.Application.Interfaces.Repositories.LMS;
public interface ICourseQuestionRepository
{
    IQueryable<CourseQuestion> CourseQuestions { get; }

    Task<List<CourseQuestion>> GetListAsync();

    Task<CourseQuestion> GetByIdAsync(int courseQuestionId);

    Task<int> InsertAsync(CourseQuestion courseQuestion);

    Task UpdateAsync(CourseQuestion courseQuestion);

    Task DeleteAsync(CourseQuestion courseQuestion);
}
