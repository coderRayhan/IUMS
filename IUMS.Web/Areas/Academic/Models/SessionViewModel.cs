using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IUMS.Web.Areas.Academic.Models
{
    public class SessionViewModel
    {
        public SessionViewModel()
        {
            Local = System.Globalization.CultureInfo.CurrentCulture.Name ;
        }
        public int Id { get; set; }
        public string SessionName { get; set; }
        //public string SessionName_EN { get; set; }
        public string SessionNameBN { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SessionStartDate { get; set; }
        public string SessionEndDate { get; set; }
        public string SessionCode { get; set; }
        public string Local { get; set; }
        public string SLNoBN { get; set; }
        public string Status { get; set; }
        //---------
        public string MenuName { get; set; }
        public string MenuNameBN { get; set; }
        public string MenuUrl { get; set; }
        public int MenuId { get; set; }
    }
}
