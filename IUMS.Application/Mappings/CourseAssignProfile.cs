using AutoMapper;
using IUMS.Application.Features.Academic.CourseAssigns.Commands;
using IUMS.Application.Features.Academic.CourseAssigns.Queries;
using IUMS.Domain.Entities.Academic;

namespace IUMS.Application.Mappings;
public class CourseAssignProfile : Profile
{
    public CourseAssignProfile()
    {
        CreateMap<CourseAssign, CreateCourseAssignCommand>().ReverseMap();
        CreateMap<CourseAssign, UpdateCourseAssignCommand>().ReverseMap();
        CreateMap<CourseAssign, CourseAssignResponse>().ReverseMap();
    }
}
