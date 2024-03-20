using AspNetCoreHero.Abstractions.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUMS.Domain.Entities.LMS
{
    [Table("LMS_ZoomClasses")]
	public class ZoomClass : AuditableEntity
	{
		public int CourseMasterId { get; set; }
		public int CourseChapterId { get; set; }
		public int ChapterClassId { get; set; }
		public int HostConfigId { get; set; }
		public DateTime SessionDate { get; set; }
		public TimeSpan StartTime { get; set; }
		public TimeSpan EndTime { get; set; }
		public decimal Duration { get; set; }
	}
}
