using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AspNetCoreHero.Abstractions.Domain;

namespace IUMS.Domain.Entities.Common;
[Table("Com_LookupDetails")]
public class LookupDetail : AuditableEntity
{
    public int LookupId { get; set; }
    [StringLength(100)]
    public string Code { get; set; }

    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(100)]
    public string NameBN { get; set; }

    [StringLength(500)]
    public string Description { get; set; }

    public int? ParentId { get; set; }

    [StringLength(50)]
    public string Status { get; set; }


}
