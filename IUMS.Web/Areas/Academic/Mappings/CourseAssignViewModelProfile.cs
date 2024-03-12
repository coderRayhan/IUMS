using AutoMapper;
using IUMS.Application.Features.Academic.CourseAssigns.Commands;
using IUMS.Application.Features.Academic.CourseAssigns.Queries;
using IUMS.Web.Areas.Academic.Models;

namespace IUMS.Web.Areas.Academic.Mappings;

public class CourseAssignViewModelProfile : Profile
{
    public CourseAssignViewModelProfile()
    {
        CreateMap<CourseAssignViewModel, CreateCourseAssignCommand>().ReverseMap();
        CreateMap<CourseAssignViewModel, UpdateCourseAssignCommand>().ReverseMap();
        CreateMap<CourseAssignViewModel, CourseAssignResponse>().ReverseMap();
    }
}
