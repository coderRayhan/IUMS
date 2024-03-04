namespace IUMS.Application.Features.Student.StudentBasicInfos.Queries;
public class StudentEducationalInfoResponse
{
    public int Id { get; set; }
    public int StudentBasicInfoId { get; set; }
    public int ExamId { get; set; }
    public int PassingYear { get; set; }
    public string InstitutionName { get; set; }
    public long RollNumber { get; set; }
    public int BoardId { get; set; }
    public decimal ExamResult { get; set; }
}
