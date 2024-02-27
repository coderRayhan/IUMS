namespace IUMS.Application.Features.Academic.Faculty.Queries
{
    public class FacultyResponse
    {
        public int Id { get; set; }
        public string FacultyName { get; set; }
        public string FacultyNameBN { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool HasAffiliatedInstitute { get; set; }
        public int AffiliatedInstituteId { get; set; }
        public string AffiliatedInstituteName { get; set; }
    }
}
