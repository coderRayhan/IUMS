using AutoMapper;
using IUMS.Application.Features.LMS.ChapterClasses.Commands;
using IUMS.Application.Features.LMS.ChapterClasses.Queries;
using IUMS.Application.Features.LMS.CourseChapters.Queries;
using IUMS.Application.Features.LMS.CourseMasters.Commands;
using IUMS.Application.Features.LMS.CourseMasters.Queries;
using IUMS.Application.Features.LMS.CourseOutcomes.Queries;
using IUMS.Application.Features.LMS.CourseQuestions.Commands;
using IUMS.Application.Features.LMS.CourseQuestions.Queries;
using IUMS.Web.Areas.LMS.Models;

namespace IUMS.Web.Areas.LMS.Mappings;

public class LMSViewModelProfile : Profile
{
    public LMSViewModelProfile()
    {
        CreateMap<CourseMasterViewModel, CourseMasterResponse>().ReverseMap();
        CreateMap<CourseMasterViewModel, CreateCourseMasterCommand>().ReverseMap();
        CreateMap<CourseMasterViewModel, UpdateCourseMasterCommand>().ReverseMap();

        CreateMap<ChapterClassViewModel, ChapterClassResponse>().ReverseMap();
        CreateMap<ChapterClassViewModel, CreateChapterClassCommand>().ReverseMap();
        CreateMap<ChapterClassViewModel, UpdateChapterClassCommand>().ReverseMap();

        CreateMap<CourseChapterViewModel, CourseChapterResponse>().ReverseMap();
        
        CreateMap<CourseFAQViewModel, CourseFAQResponse>().ReverseMap();

        CreateMap<CourseOutcomeViewModel, CourseOutcomeResponse>().ReverseMap();

        CreateMap<CourseQuestionViewModel, CommonProperties>().ReverseMap();
        CreateMap<CourseQuestionViewModel, CourseQuestionResponse>().ReverseMap();
        CreateMap<CourseQuestionViewModel, CreateCourseQuestionCommand>().ReverseMap();
        CreateMap<CourseQuestionViewModel, UpdateCourseQuestionCommand>().ReverseMap();
    }
}
