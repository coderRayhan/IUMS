using AutoMapper;
using IUMS.Application.Features.Academic;
using IUMS.Domain.Entities.Academic;

namespace IUMS.Application.Mappings
{
    public class SessionProfile : Profile
    {
        public SessionProfile()
        {
            CreateMap<Session, CreateSessionCommand>().ReverseMap();
            CreateMap<Session, UpdateSessionCommand>().ReverseMap();
            CreateMap<Session, SessionResponse>().ReverseMap();
        }
    }
}
