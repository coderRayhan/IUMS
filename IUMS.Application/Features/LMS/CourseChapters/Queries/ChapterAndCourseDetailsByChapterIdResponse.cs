namespace IUMS.Application.Features.LMS.CourseChapters.Queries
{
    public class ChapterAndCourseDetailsByChapterIdResponse
	{
		public int CourseMasterId { get; set; }
		public int CourseChapterId { get; set; }
		public string CourseName { get; set; }
		public string CourseCode { get; set; }
		public int ChapterNo { get; set; }
		public string ChapterTitle { get; set; }
		public decimal ChapterDuration { get; set; }
		public decimal ConductHour { get; set; }
		public decimal CreditHour { get; set; }
		public string TeacherName { get; set; }
		public string PartName { get; set; }
	}
}
