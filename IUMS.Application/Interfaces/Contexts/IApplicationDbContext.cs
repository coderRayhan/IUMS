using AspNetCoreHero.Boilerplate.Domain.Entities.Catalog;
using IUMS.Domain.Entities.Academic;
using IUMS.Domain.Entities.Common;
using IUMS.Domain.Entities.Employees;
using IUMS.Domain.Entities.LMS;
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
        public DbSet<CourseAssign> CourseAssigns { get; set; }
        public DbSet<TeacherAssign> TeacherAssigns { get; set; }
        #endregion

        #region Common
        DbSet<Lookup> Lookups { get; set; }
        DbSet<LookupDetail> LookupDetails { get; set; }
        #endregion

        #region Student
        DbSet<StudentBasicInfo> StudentBasicInfos { get; set; }
        DbSet<StudentEducationalInfo> StudentEducationalInfos { get; set; }
        #endregion

        #region Employee
        public DbSet<Employee> Employees { get; set; }
        #endregion

        #region LMS
        public DbSet<CourseMaster> CourseMasters { get; set; }
        public DbSet<CourseChapter> CourseChapters { get; set; }
        public DbSet<CourseOutcome> CourseOutcomes { get; set; }
        public DbSet<CourseFAQ> CourseFAQs { get; set; }
        public DbSet<ChapterClass> ChapterClasses { get; set; }
        public DbSet<CourseQuestion> CourseQuestions { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }
        public DbSet<CourseExam> CourseExams { get; set; }
        public DbSet<StudentEvaluation> StudentEvaluations { get; set; }
        public DbSet<StudentEvaluationDetail> StudentEvaluationDetails { get; set; }
        public DbSet<HostConfig> HostConfigs { get; set; }
        public DbSet<ZoomClass> ZoomClasses { get; set; }
        #endregion

        DbSet<Product> Products { get; set; }
    }
}