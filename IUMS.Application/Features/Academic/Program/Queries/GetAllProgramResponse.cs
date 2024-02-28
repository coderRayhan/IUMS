namespace IUMS.Application.Features.Academic.Program.Queries
{
    public class GetAllProgramResponse
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ProgramName { get; set; }
        public string ProgramNameBN { get; set; }
        public decimal CreditPoints { get; set; }
        public int FacultyId { get; set; }
        public int DepartmentId { get; set; }
        public string FacultyName { get; set; }
        public string FacultyNameBN { get; set; }

        public string DepartmentName { get; set; }
        public string DepartmentNameBN { get; set; }
        public int YearDuration { get; set; }
        public string SLNoBN { get; set; }
    }


    public class GetProgByDeptResponse
    {
        public int Id { get; set; }
        public string ProgramName { get; set; }
        public string ProgramNameBN { get; set; }
    }
}

