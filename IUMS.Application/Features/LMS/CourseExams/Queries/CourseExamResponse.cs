using IUMS.Application.Features.LMS.ExamQuestions.Queries;
using System;
using System.Collections.Generic;

namespace IUMS.Application.Features.LMS.CourseExams.Queries
{
    public class CourseExamResponse
	{
		public int Id { get; set; }
		//Extra property for view
		public int AdmissionYearId { get; set; }
		public int FacultyId { get; set; }
		public int DepartmentId { get; set; }
		public int ProgramId { get; set; }
		public int BatchId { get; set; }
		public int SemesterId { get; set; }
		public int PartId { get; set; }
		public string PartName { get; set; }
		public string PartNameBN { get; set; }
		public int CourseMasterId { get; set; }
		public int CourseChapterId { get; set; }
		public int ChapterClassId { get; set; }
		public int FollowedByChapterId { get; set; }
		public string CourseName { get; set; }
		public string CourseCode { get; set; }
		public int ExamTypeId { get; set; }
		public int ExamNameId { get; set; }
		public int NoOfQuestions { get; set; }
		public int QuesToBeAnswered { get; set; }
		public decimal TotalMarks { get; set; }
		public decimal PassMark { get; set; }
		public decimal Duration { get; set; }
		public DateTime? StartDate { get; set; }
		public TimeSpan StartTime { get; set; }
		public DateTime? EndDate { get; set; }
		public TimeSpan EndTime { get; set; }
		public bool IsActive { get; set; }
		public bool IsSelected { get; set; }
		public string AssignmentDetails { get; set; }
		public string AssignmentUrl { get; set; }
		public bool IsAnyStudentSubmit { get; set; }
		public List<ExamQuestionResponse> ExamQuestions { get; set; }
	}
}
