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
public class CourseQuestionRepository : ICourseQuestionRepository
{
    private readonly IRepositoryAsync<CourseQuestion> _repository;

    public CourseQuestionRepository(IRepositoryAsync<CourseQuestion> repository)
    {
        _repository = repository;
    }

    public IQueryable<CourseQuestion> CourseQuestions => _repository.Entities;

    public async Task DeleteAsync(CourseQuestion courseQuestion)
    {
        await _repository.DeleteAsync(courseQuestion);
    }

    public Task<CourseQuestion> GetByIdAsync(int courseQuestionId)
    {
        return _repository.Entities
            .Where(e => e.Id  == courseQuestionId)
            .Include(e => e.QuestionOptions)
            .FirstOrDefaultAsync();
    }

    public async Task<List<CourseQuestion>> GetListAsync()
    {
        return await _repository.Entities
            .Include(e => e.QuestionOptions)
            .ToListAsync();
    }

    public async Task<int> InsertAsync(CourseQuestion courseQuestion)
    {
        await _repository.AddAsync(courseQuestion);
        return courseQuestion.Id;
    }

    public async Task UpdateAsync(CourseQuestion courseQuestion)
    {
        await _repository.UpdateAsync(courseQuestion);
    }
}
