using AutoMapper;
using IUMS.Application.Features.Employees.Commands;
using IUMS.Application.Features.Employees.Queries;
using IUMS.Domain.Entities.Employees;

namespace IUMS.Application.Mappings;
internal class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();
        CreateMap<Employee, UpdateEmployeeCommand>().ReverseMap();
        CreateMap<Employee, EmployeeResponse>().ReverseMap();
    }
}
