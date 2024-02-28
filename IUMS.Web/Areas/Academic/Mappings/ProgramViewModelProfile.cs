using AutoMapper;
using IUMS.Application.Features;
using IUMS.Application.Features.Academic.Program.Queries;
using IUMS.Web.Areas.Academic.Models;

namespace IUMS.Web.Areas.Academic.Mappings
{
    public class ProgramViewModelProfile : Profile
    {
        public ProgramViewModelProfile()
        {
            CreateMap<ProgramViewModel, CreateProgramCommand>().ReverseMap();
            CreateMap<ProgramViewModel, UpdateProgramCommand>().ReverseMap();
            CreateMap<ProgramViewModel, GetAllProgramResponse>().ReverseMap();
        }
    }
}
