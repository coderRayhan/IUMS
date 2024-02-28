using IUMS.Application.Features.Academic.Department.Queries;
using IUMS.Application.Features;
using IUMS.Domain.Entities.Academic;
using IUMS.Web.Areas.Academic.Models;
using AutoMapper;

namespace IUMS.Web.Areas.Academic.Mappings
{
    public class DepartmentViewModelProfile : Profile
    {
        public DepartmentViewModelProfile()
        {
            CreateMap<DepartmentViewModel, CreateDepartmentCommand>().ReverseMap();
            CreateMap<DepartmentViewModel, UpdateDepartmentCommand>().ReverseMap();
            CreateMap<DepartmentViewModel, GetAllDepartmentResponse>().ReverseMap();
        }
    }
}
