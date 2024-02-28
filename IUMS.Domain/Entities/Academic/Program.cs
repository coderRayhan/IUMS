using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AspNetCoreHero.Abstractions.Domain;

namespace IUMS.Domain.Entities.Academic
{
    [Table("Aca_Programs")]
    public class Program : AuditableEntity
    {
        public string Code { get; set; }
        [StringLength(500)]
        public string ProgramName { get; set; }

        [StringLength(500)]
        public string ProgramNameBN { get; set; }
        public int DepartmentId { get; set; }
        public decimal CreditPoints { get; set; }
        public int YearDuration { get; set; }
        public virtual Department Department { get; set; }
    }
}
