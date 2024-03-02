using AutoMapper;
using IUMS.Application.Features;
using IUMS.Domain.Entities.Academic;

namespace IUMS.Application.Mappings;
public class BatchProfile : Profile
{
    public BatchProfile()
    {
        CreateMap<BatchResponse, Batch>().ReverseMap();
        CreateMap<CreateBatchCommand, Batch>().ReverseMap();
        CreateMap<UpdateBatchCommand, Batch>().ReverseMap();
    }
}
