using AutoMapper;
using IUMS.Application.Features.Academic.TeacherAssigns.Commands;
using IUMS.Application.Features.Academic.TeacherAssigns.Queries;
using IUMS.Domain.Entities.Academic;

namespace IUMS.Application.Mappings;
public class TeacherAssignProfile : Profile
{
    public TeacherAssignProfile()
    {
        CreateMap<TeacherAssignResponse, TeacherAssign>().ReverseMap();
        CreateMap<CreateTeacherAssignCommand, TeacherAssign>().ReverseMap();
        CreateMap<UpdateTeacherAssignCommand, TeacherAssign>().ReverseMap();
    }
}
