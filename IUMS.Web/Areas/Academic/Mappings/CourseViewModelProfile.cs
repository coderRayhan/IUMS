using AutoMapper;
using IUMS.Application.Features.Academic.Courses.Commands;
using IUMS.Application.Features.Academic.Courses.Queries;
using IUMS.Web.Areas.Academic.Models;

namespace IUMS.Web.Areas.Academic.Mappings;

public class CourseViewModelProfile : Profile
{
    public CourseViewModelProfile()
    {
        CreateMap<CourseViewModel, CourseResponse>().ReverseMap();
        CreateMap<CourseViewModel, CreateCourseCommand>().ReverseMap();
        CreateMap<CourseViewModel, UpdateCourseCommand>().ReverseMap();
    }
}
