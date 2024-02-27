using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AspNetCoreHero.Abstractions.Domain;

namespace IUMS.Domain.Entities.Academic
{
    [Table("Aca_Faculties")]
    public class Faculty : AuditableEntity
    {
        [StringLength(200)]
        public string FacultyName { get; set; }
        [StringLength(200)]
        public string FacultyNameBN { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public int WingId { get; set; }
        public bool HasAffiliatedInstitute { get; set; }
        public int AffiliatedInstituteId { get; set; }
    }
}
