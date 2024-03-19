using IUMS.Domain.Entities.Academic;
using IUMS.Domain.Entities.LMS;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IUMS.Application.Interfaces.Repositories.LMS;
public interface IQuestionOptionRepository
{
    IQueryable<QuestionOption> QuestionOptions { get; }

    Task<List<QuestionOption>> GetListAsync();

    Task<QuestionOption> GetByIdAsync(int questionOptionId);

    Task<int> InsertAsync(QuestionOption questionOption);

    Task UpdateAsync(QuestionOption questionOption);

    Task DeleteAsync(QuestionOption questionOption);
}
