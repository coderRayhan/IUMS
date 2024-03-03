using AutoMapper;
using IUMS.Application.Features.Academic.Lookup.Commands;
using IUMS.Application.Features.Academic.Lookup.Queries;
using IUMS.Application.Features.Common;
using IUMS.Web.Areas.Academic.Models;

namespace IUMS.Web.Areas.Common.Mappings;

public class LookupViewModelProfile : Profile
{
    public LookupViewModelProfile()
    {
        CreateMap<LookupViewModel, CreateLookupCommand>().ReverseMap();
        CreateMap<LookupViewModel, UpdateLookupCommand>().ReverseMap();
        CreateMap<LookupViewModel, LookupResponse>().ReverseMap();
    }
}
