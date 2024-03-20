namespace IUMS.Application.Features.LMS.CourseAssignments.Queries;
public class CourseAssignmentResponse
{
    public string ClassRollNo { get; set; }
    public string ApplicantName { get; set; }
    public string FileUrl { get; set; }
    public string SubmittedDate { get; set; }
    public int StdEvaluationId { get; set; }
    public bool SubmittedStatus { get; set; }
}
