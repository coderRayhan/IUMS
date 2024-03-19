using AutoMapper;
using IUMS.Application.Features.Academic.TeacherAssigns.Commands;
using IUMS.Application.Features.Academic.TeacherAssigns.Queries;
using IUMS.Web.Areas.Academic.Models;

namespace IUMS.Web.Areas.Academic.Mappings;

public class TeacherAssignViewModelProfile : Profile
{
    public TeacherAssignViewModelProfile()
    {
        CreateMap<TeacherAssignViewModel, TeacherAssignResponse>().ReverseMap();
        CreateMap<TeacherAssignViewModel, CreateTeacherAssignCommand>().ReverseMap();
        CreateMap<TeacherAssignViewModel, UpdateTeacherAssignCommand>().ReverseMap();
    }
}
