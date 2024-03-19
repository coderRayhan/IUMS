using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Academic;
using IUMS.Application.Interfaces.Repositories.LMS;
using IUMS.Domain.Entities.Academic;
using IUMS.Domain.Entities.LMS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUMS.Infrastructure.Repositories.LMS;
public class CourseExamRepository : ICourseExamRepository
{
    private readonly IRepositoryAsync<CourseExam> _repository;

    public IQueryable<CourseExam> CourseExams => _repository.Entities;

    public async Task DeleteAsync(CourseExam courseExam)
    {
        await _repository.DeleteAsync(courseExam);
    }

    public async Task<CourseExam> GetByIdAsync(int courseExamId)
    {
        return await _repository.Entities.Where(e => e.Id == courseExamId).Include(e => e.ExamQuestions).FirstOrDefaultAsync();
    }

    public async Task<List<CourseExam>> GetListAsync()
    {
        return await _repository.Entities.Include(e => e.ExamQuestions).ToListAsync();
    }

    public async Task<int> InsertAsync(CourseExam courseExam)
    {
        await _repository.AddAsync(courseExam);
        return courseExam.Id;
    }

    public async Task UpdateAsync(CourseExam courseExam)
    {
        await _repository.UpdateAsync(courseExam);
    }
}
