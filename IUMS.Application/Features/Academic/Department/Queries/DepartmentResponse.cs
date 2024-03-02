namespace IUMS.Application.Features.Academic.Department.Queries
{
    public class DepartmentResponse
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentNameBN { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }
        public string FacultyNameBN { get; set; }
        public string SLNoBN { get; set; }
    }

    public class GetDeptByFacultyResponse
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentNameBN { get; set; }
    }

}
