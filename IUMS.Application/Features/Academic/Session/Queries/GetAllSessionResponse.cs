using System;

namespace IUMS.Application.Features.Academic
{
    public class GetAllSessionResponse
    {
        public int Id { get; set; }
        public string SessionName { get; set; }
        public string SessionNameBN { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SessionStartDate { get; set; }
        public string SessionEndDate { get; set; }
        public string SessionCode { get; set; }
        public string SLNoBN { get; set; }
        public string Status { get; set; }
    }
}
