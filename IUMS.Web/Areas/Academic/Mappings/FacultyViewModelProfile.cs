using AutoMapper;
using IUMS.Application.Features;
using IUMS.Application.Features.Academic.Faculty.Queries;
using IUMS.Web.Areas.Academic.Models;
using UEMS.Application.Features;

namespace IUMS.Web.Areas.Academic.Mappings
{
    public class FacultyViewModelProfile : Profile
    {
        public FacultyViewModelProfile()
        {
            CreateMap<FacultyViewModel, CreateFacultyCommand>().ReverseMap();
            CreateMap<FacultyViewModel, UpdateFacultyCommand>().ReverseMap();
            CreateMap<FacultyViewModel, FacultyResponse>().ReverseMap();
        }
    }
}
