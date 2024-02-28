using AspNetCoreHero.Boilerplate.Domain.Entities.Catalog;
using IUMS.Domain.Entities.Academic;
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

        DbSet<Product> Products { get; set; }
        DbSet<Session> Sessions { get; set; }
        DbSet<Faculty> Faculties { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Program> Programs { get; set; }
        DbSet<Batch> Batches { get; set; }
    }
}