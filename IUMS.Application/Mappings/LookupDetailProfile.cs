using AutoMapper;
using IUMS.Application.Features.Academic.LookupDetail.Commands;
using IUMS.Application.Features.Academic.LookupDetail.Queries;
using IUMS.Application.Features.Common;
using IUMS.Domain.Entities.Common;

namespace IUMS.Application.Mappings;
public class LookupDetailProfile : Profile
{
    public LookupDetailProfile()
    {
        CreateMap<LookupDetail, CreateLookupDetailCommand>().ReverseMap();
        CreateMap<LookupDetail, UpdateLookupDetailCommand>().ReverseMap();
        CreateMap<LookupDetail, LookupDetailResponse>().ReverseMap();
    }
}
