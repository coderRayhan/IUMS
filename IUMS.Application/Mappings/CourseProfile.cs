using AutoMapper;
using IUMS.Application.Features.Academic.Courses.Commands;
using IUMS.Application.Features.Academic.Courses.Queries;
using IUMS.Domain.Entities.Academic;

namespace IUMS.Application.Mappings;
public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<Course, CourseResponse>().ReverseMap();
        CreateMap<Course, CreateCourseCommand>().ReverseMap();
        CreateMap<Course, UpdateCourseCommand>().ReverseMap();
    }
}
