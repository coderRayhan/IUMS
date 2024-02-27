namespace IUMS.Web.Areas.Academic.Models
{
    public class FacultyViewModel
    {
        public int Id { get; set; }  
        public string FacultyName { get; set; }
        public string FacultyNameBN { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Local { get; set; }
        public bool HasAffiliatedInstitute { get; set; }
        public int AffiliatedInstituteId { get; set; }
        public string AffiliatedInstituteName { get; set; }
    }
}
