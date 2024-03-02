using AutoMapper;
using IUMS.Application.Features;
using IUMS.Application.Features.Academic.Program.Queries;
using IUMS.Domain.Entities.Academic;

namespace IUMS.Application.Mappings
{
    public class ProgramProfile : Profile
    {
        public ProgramProfile()
        {
            CreateMap<Program, CreateProgramCommand>().ReverseMap();
            CreateMap<Program, UpdateProgramCommand>().ReverseMap();
            CreateMap<Program, ProgramResponse>().ReverseMap();
        }
    }
}
