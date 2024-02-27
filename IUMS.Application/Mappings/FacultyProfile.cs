using AutoMapper;
using IUMS.Application.Features;
using IUMS.Application.Features.Academic.Faculty.Queries;
using IUMS.Domain.Entities.Academic;
using UEMS.Application.Features;

namespace IUMS.Application.Mappings
{
    public class FacultyProfile : Profile
    {
        public FacultyProfile()
        {
            CreateMap<Faculty,CreateFacultyCommand>().ReverseMap();
            CreateMap<Faculty,UpdateFacultyCommand>().ReverseMap();
            CreateMap<Faculty,FacultyResponse>().ReverseMap();
        }
    }
}
