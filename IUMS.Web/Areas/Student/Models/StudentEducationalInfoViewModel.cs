namespace IUMS.Web.Areas.Student.Models;

public class StudentEducationalInfoViewModel
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
