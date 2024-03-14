using AutoMapper;
using IUMS.Application.Features.Employees.Commands;
using IUMS.Application.Features.Employees.Queries;
using IUMS.Web.Areas.Employees.Models;

namespace IUMS.Web.Areas.Employees.Mappings;

public class EmployeeViewModelProfile : Profile
{
    public EmployeeViewModelProfile()
    {
        CreateMap<EmployeeViewModel, CreateEmployeeCommand>().ReverseMap();
        CreateMap<EmployeeViewModel, UpdateEmployeeCommand>().ReverseMap();
        CreateMap<EmployeeViewModel, EmployeeResponse>().ReverseMap();
    }
}
