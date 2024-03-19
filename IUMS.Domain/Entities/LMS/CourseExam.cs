using AspNetCoreHero.Abstractions.Domain;
using IUMS.Domain.Entities.LMS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUMS.Domain.Entities.LMS
{
    [Table("LMS_CourseExams")]
	public class CourseExam : AuditableEntity
	{
		public int CourseMasterId { get; set; }
		public int CourseChapterId { get; set; }
		public int ChapterClassId { get; set; }
		public int FollowedByChapterId { get; set; }
		public int ExamTypeId { get; set; }
		public int ExamNameId { get; set; }    //Mid term / Final
		public int NoOfQuestions { get; set; }
		public int QuesToBeAnswered { get; set; }
		public decimal TotalMarks { get; set; }
		public decimal PassMark { get; set; }
		public decimal Duration { get; set; }
		public DateTime StartDate { get; set; }
		public TimeSpan StartTime { get; set; }
		public DateTime EndDate { get; set; }
		public TimeSpan EndTime { get; set; }
		public bool IsActive { get; set; }
		public string AssignmentDetails { get; set; }
		public string AssignmentUrl { get; set; }
		public List<ExamQuestion> ExamQuestions { get; set; }
        public virtual CourseMaster CourseMaster { get; set; }
    }
}
