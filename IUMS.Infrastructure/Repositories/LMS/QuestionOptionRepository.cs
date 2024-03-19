using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.LMS;
using IUMS.Domain.Entities.LMS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUMS.Infrastructure.Repositories.LMS;
public class QuestionOptionRepository : IQuestionOptionRepository
{
    private readonly IRepositoryAsync<QuestionOption> _repository;

    public QuestionOptionRepository(IRepositoryAsync<QuestionOption> repository)
    {
        _repository = repository;
    }

    public IQueryable<QuestionOption> QuestionOptions => _repository.Entities;

    public async Task DeleteAsync(QuestionOption questionOption)
    {
        await _repository.DeleteAsync(questionOption);
    }

    public async Task<QuestionOption> GetByIdAsync(int questionOptionId)
    {
        return await _repository.Entities
            .Where(e => e.Id == questionOptionId)
            .FirstOrDefaultAsync();
    }

    public async Task<List<QuestionOption>> GetListAsync()
    {
        return await _repository.Entities.ToListAsync();
    }

    public async Task<int> InsertAsync(QuestionOption questionOption)
    {
        await _repository.AddAsync(questionOption);
        return questionOption.Id;
    }

    public async Task UpdateAsync(QuestionOption questionOption)
    {
        await _repository.UpdateAsync(questionOption);
    }
}
