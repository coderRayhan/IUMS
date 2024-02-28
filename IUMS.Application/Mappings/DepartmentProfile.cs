using AutoMapper;
using IUMS.Application.Features;
using IUMS.Application.Features.Academic.Department.Queries;
using IUMS.Domain.Entities.Academic;

namespace IUMS.Application.Mappings
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, CreateDepartmentCommand>().ReverseMap();
            CreateMap<Department, UpdateDepartmentCommand>().ReverseMap();
            CreateMap<Department, GetAllDepartmentResponse>().ReverseMap();
        }
    }
}
