using IUMS.Domain.Entities.Student;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IUMS.Application.Interfaces.Repositories.Student;
public interface IStudentBasicInfoRepository
{
    IQueryable<StudentBasicInfo> StudentBasicInfos { get; }

    Task<List<StudentBasicInfo>> GetListAsync();

    Task<StudentBasicInfo> GetByIdAsync(int studentId);

    Task<int> InsertAsync(StudentBasicInfo studentBasicInfo);

    Task UpdateAsync(StudentBasicInfo studentBasicInfo);

    Task DeleteAsync(StudentBasicInfo studentBasicInfo);
}
