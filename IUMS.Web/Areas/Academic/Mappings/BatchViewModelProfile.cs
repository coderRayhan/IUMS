using AutoMapper;
using IUMS.Application.Features;
using IUMS.Web.Areas.Academic.Models;

namespace IUMS.Web.Areas.Academic.Mappings;

public class BatchViewModelProfile : Profile
{
    public BatchViewModelProfile()
    {
        CreateMap<BatchViewModel, BatchResponse>().ReverseMap();
        CreateMap<BatchViewModel, CreateBatchCommand>().ReverseMap();
        CreateMap<BatchViewModel, UpdateBatchCommand>().ReverseMap();
    }
}
