using IUMS.Domain.Entities.Academic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUMS.Application.Interfaces.Repositories.Academic
{
    public interface ITeacherAssignRepository
    {
        IQueryable<TeacherAssign> TeacherAssigns { get; }

        Task<List<TeacherAssign>> GetListAsync();

        Task<TeacherAssign> GetByIdAsync(int teacherAssignId);

        Task<int> InsertAsync(TeacherAssign teacherAssign);

        Task UpdateAsync(TeacherAssign teacherAssign);

        Task DeleteAsync(TeacherAssign teacherAssign);
    }
}
