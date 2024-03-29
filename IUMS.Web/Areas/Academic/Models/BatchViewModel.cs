﻿namespace IUMS.Web.Areas.Academic.Models
{
    public class BatchViewModel
    {
        public BatchViewModel()
        {
            Local = System.Globalization.CultureInfo.CurrentCulture.Name;
        }


        public int Id { get; set; }
        public int SessionId { get; set; }
        public int FacultyId { get; set; }
        public int DepartmentId { get; set; }
        public int ProgramId { get; set; }
        public int Capacity { get; set; }
        public string BatchName { get; set; }
        public string BatchNameBN { get; set; }

        public string SessionName { get; set; }
        public string SessionNameBN { get; set; }
        public string FacultyName { get; set; }
        public string FacultyNameBN { get; set; }

        public string DepartmentName { get; set; }
        public string DepartmentNameBN { get; set; }

        public string ProgramName { get; set; }
        public string ProgramNameBN { get; set; }
        public string Code { get; set; }
        public string CodeBN { get; set; }

        public string Local { get; set; }
        //---------
        public string MenuName { get; set; }
        public string MenuNameBN { get; set; }
        public string MenuUrl { get; set; }
        public int MenuId { get; set; }
    }
}
