using AutoMapper;
using IUMS.Application.Features.Academic;
using IUMS.Web.Areas.Academic.Models;

namespace IUMS.Web.Areas.Academic.Mappings
{
    public class SessionViewModelProfile : Profile
    {
        public SessionViewModelProfile()
        {
            CreateMap<SessionViewModel, CreateSessionCommand>().ReverseMap();
            CreateMap<SessionViewModel, UpdateSessionCommand>().ReverseMap();
            CreateMap<SessionViewModel, GetAllSessionResponse>().ReverseMap();
        }
    }
}
