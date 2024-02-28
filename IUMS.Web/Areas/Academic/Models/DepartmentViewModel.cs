namespace IUMS.Web.Areas.Academic.Models
{
    public class DepartmentViewModel
    {
        public DepartmentViewModel()
        {
            Local = System.Globalization.CultureInfo.CurrentCulture.Name;
        }
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentNameBN { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }
        public string FacultyNameBN { get; set; }
        public string Local { get; set; }
        //---------
        public string MenuName { get; set; }
        public string MenuNameBN { get; set; }
        public string MenuUrl { get; set; }
        public int MenuId { get; set; }
    }
}
