using AspNetCoreHero.Boilerplate.Domain.Entities.Catalog;
using IUMS.Domain.Entities.Academic;
using IUMS.Domain.Entities.Common;
using IUMS.Domain.Entities.Student;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Application.Interfaces.Contexts
{
    public interface IApplicationDbContext
    {
        IDbConnection Connection { get; }
        bool HasChanges { get; }

        EntityEntry Entry(object entity);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        #region Academic
        DbSet<Session> Sessions { get; set; }
        DbSet<Faculty> Faculties { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Program> Programs { get; set; }
        DbSet<Batch> Batches { get; set; }
        public DbSet<Course> Courses { get; set; }
        #endregion

        #region Common
        DbSet<Lookup> Lookups { get; set; }
        DbSet<LookupDetail> LookupDetails { get; set; }
        #endregion

        #region Student
        DbSet<StudentBasicInfo> StudentBasicInfos { get; set; }
        DbSet<StudentEducationalInfo> StudentEducationalInfos { get; set; }
        #endregion

        DbSet<Product> Products { get; set; }
    }
}