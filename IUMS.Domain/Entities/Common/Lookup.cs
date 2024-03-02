using AspNetCoreHero.Abstractions.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUMS.Domain.Entities.Common;
[Table("Com_Lookups")]
public class Lookup : AuditableEntity
{
    [StringLength(100)]
    public string Code { get; set; }

    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(100)]
    public string NameBN { get; set; }

    public int? ParentId { get; set; }

    [StringLength(50)]
    public string Status { get; set; }
    public int DevCode { get; set; }
}
