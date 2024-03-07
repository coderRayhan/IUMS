using AspNetCoreHero.Abstractions.Domain;
using AspNetCoreHero.Boilerplate.Application.Interfaces.Contexts;
using AspNetCoreHero.Boilerplate.Application.Interfaces.Shared;
using AspNetCoreHero.Boilerplate.Domain.Entities.Catalog;
using AspNetCoreHero.EntityFrameworkCore.AuditTrail;
using IUMS.Domain.Entities.Academic;
using IUMS.Domain.Entities.Common;
using IUMS.Domain.Entities.Student;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Infrastructure.DbContexts
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly IDateTimeService _dateTime;
        private readonly IAuthenticatedUserService _authenticatedUser;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser) : base(options)
        {
            _dateTime = dateTime;
            _authenticatedUser = authenticatedUser;
        }

        public DbSet<Product> Products { get; set; }

        public IDbConnection Connection => Database.GetDbConnection();

        public bool HasChanges => ChangeTracker.HasChanges();

        public DbSet<Session> Sessions { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Lookup> Lookups { get; set; }
        public DbSet<LookupDetail> LookupDetails { get; set; }
        public DbSet<StudentBasicInfo> StudentBasicInfos { get; set; }
        public DbSet<StudentEducationalInfo> StudentEducationalInfos { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,2)");
            }
            base.OnModelCreating(builder);
        }
    }
}