using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AspNetCoreHero.Abstractions.Domain;

namespace IUMS.Domain.Entities.Academic
{
    [Table("Aca_Batches")]
    public class Batch : AuditableEntity
    {
        public int SessionId { get; set; }
        public int FacultyId { get; set; }
        public int DepartmentId { get; set; }
        public int ProgramId { get; set; }
        public int Capacity { get; set; }
        [StringLength(100)]
        public string BatchName { get; set; }
        [StringLength(100)]
        public string BatchNameBN { get; set; }
        [StringLength(100)]
        public string Code { get; set; }

        public virtual Faculty Faculty { get; set; }
        public virtual Department Department { get; set; }
        public virtual Program Program { get; set; }
    }
}
