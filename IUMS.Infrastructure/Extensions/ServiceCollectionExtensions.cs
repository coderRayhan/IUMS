using AspNetCoreHero.Boilerplate.Application.Interfaces.CacheRepositories;
using AspNetCoreHero.Boilerplate.Application.Interfaces.Contexts;
using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using AspNetCoreHero.Boilerplate.Infrastructure.CacheRepositories;
using AspNetCoreHero.Boilerplate.Infrastructure.DbContexts;
using AspNetCoreHero.Boilerplate.Infrastructure.Repositories;
using IUMS.Application.Interfaces.Contexts;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Academic;
using IUMS.Application.Interfaces.Repositories.Common;
using IUMS.Application.Interfaces.Repositories.Employees;
using IUMS.Application.Interfaces.Repositories.Student;
using IUMS.Infrastructure.DbContexts;
using IUMS.Infrastructure.Interceptors;
using IUMS.Infrastructure.Repositories.Academic;
using IUMS.Infrastructure.Repositories.Common;
using IUMS.Infrastructure.Repositories.Employees;
using IUMS.Infrastructure.Repositories.Student;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IUMS.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistenceContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IDapperContext, DapperContext>();
            #region Repositories

            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductCacheRepository, ProductCacheRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<ISessionRepository, SessionRepository>();
            services.AddTransient<IFacultyRepository, FacultyRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IProgramRepository, ProgramRepository>();
            services.AddTransient<IBatchRepository, BatchRepository>();
            services.AddTransient<ILookupRepository, LookupRepository>();
            services.AddTransient<ILookupDetailRepository, LookupDetailRepository>();
            services.AddTransient<IStudentBasicInfoRepository, StudentBasicInfoRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<ICourseAssignRepository, CourseAssignRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IBrandCacheRepository, BrandCacheRepository>();
            services.AddTransient<ILogRepository, LogRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            #endregion Repositories
        }
    }
}