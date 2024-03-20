using AspNetCoreHero.Abstractions.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUMS.Domain.Entities.LMS
{
    [Table("LMS_HostConfigs")]
	public class HostConfig : AuditableEntity
	{
		public int TeacherId { get; set; }
		[StringLength(100)]
		public string HostName { get; set; }
		[StringLength(100)]
		public string ZoomId { get; set; }
        public string ZoomUserId { get; set; } 
        public string AccountId { get; set; } 
        public string ClientId { get; set; } 
        public string ClientSecret { get; set; } 
    }
}
