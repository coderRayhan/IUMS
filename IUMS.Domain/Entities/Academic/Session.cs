using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AspNetCoreHero.Abstractions.Domain;

namespace IUMS.Domain.Entities.Academic
{
	[Table("Aca_Sessions")]
	public class Session : AuditableEntity
	{
		[StringLength(100)]
		public string SessionName { get; set; }

		[StringLength(100)]
		public string SessionNameBN { get; set; }

		[StringLength(100)]
		public string SessionCode { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }
		[StringLength(10)]
		public string Status { get; set; }
	}
}
