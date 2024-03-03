using AutoMapper;
using IUMS.Application.Features.Academic.LookupDetail.Commands;
using IUMS.Application.Features.Academic.LookupDetail.Queries;
using IUMS.Application.Features.Common;
using IUMS.Web.Areas.Academic.Models;

namespace IUMS.Web.Areas.Common.Mappings;

public class LookupDetailViewModelProfile : Profile
{
    public LookupDetailViewModelProfile()
    {
        CreateMap<LookupDetailViewModel, CreateLookupDetailCommand>().ReverseMap();
        CreateMap<LookupDetailViewModel, UpdateLookupDetailCommand>().ReverseMap();
        CreateMap<LookupDetailViewModel, LookupDetailResponse>().ReverseMap();
    }
}
