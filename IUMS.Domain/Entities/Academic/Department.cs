using AspNetCoreHero.Abstractions.Domain;
using System.ComponentModel.DataAnnotations;

namespace IUMS.Domain.Entities.Academic
{
    public class Department : AuditableEntity
    {
        public int FacultyId { get; set; } // Fk Faculty Table
        [StringLength(200)]
        public string DepartmentName { get; set; }
        [StringLength(200)]
        public string DepartmentNameBN { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(500)]
        public string Description { get; set; }

        public virtual Faculty Faculty { get; set; }
    }
}
