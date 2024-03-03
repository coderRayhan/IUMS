using AutoMapper;
using IUMS.Application.Features;
using IUMS.Application.Features.Academic.Lookup.Commands;
using IUMS.Application.Features.Academic.Lookup.Queries;
using IUMS.Application.Features.Common;
using IUMS.Domain.Entities.Common;

namespace IUMS.Application.Mappings;
public class LookupProfile : Profile
{
    public LookupProfile()
    {
        CreateMap<Lookup, CreateLookupCommand>().ReverseMap();
        CreateMap<Lookup, UpdateLookupCommand>().ReverseMap();
        CreateMap<Lookup, LookupResponse>().ReverseMap();
    }
}
