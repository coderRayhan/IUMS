using AutoMapper;
using IUMS.Application.Features.LMS.ChapterClasses.Commands;
using IUMS.Application.Features.LMS.ChapterClasses.Queries;
using IUMS.Application.Features.LMS.CourseChapters.Commands;
using IUMS.Application.Features.LMS.CourseChapters.Queries;
using IUMS.Application.Features.LMS.CourseExams.Commands;
using IUMS.Application.Features.LMS.CourseExams.Queries;
using IUMS.Application.Features.LMS.CourseMasters.Commands;
using IUMS.Application.Features.LMS.CourseMasters.Queries;
using IUMS.Application.Features.LMS.CourseOutcomes.Queries;
using IUMS.Application.Features.LMS.CourseQuestions.Commands;
using IUMS.Application.Features.LMS.CourseQuestions.Queries;
using IUMS.Domain.Entities.LMS;

namespace IUMS.Application.Mappings;
public class LMSProfile : Profile
{
    public LMSProfile()
    {
        CreateMap<CourseMaster, CourseMasterResponse>().ReverseMap();
        CreateMap<CourseMaster, CreateCourseMasterCommand>().ReverseMap();
        CreateMap<CourseMaster, UpdateCourseMasterCommand>().ReverseMap();

        CreateMap<CourseChapter, CourseChapterResponse>().ReverseMap();
        CreateMap<CourseChapter, UpdateCourseChapterCommand>().ReverseMap();

        CreateMap<CourseOutcome, CourseOutcomeResponse>().ReverseMap();

        CreateMap<CourseFAQ, CourseFAQResponse>().ReverseMap();

        CreateMap<ChapterClass, ChapterClassResponse>().ReverseMap();
        CreateMap<ChapterClass, CreateChapterClassCommand>().ReverseMap();
        CreateMap<ChapterClass, UpdateChapterClassCommand>().ReverseMap();

        CreateMap<CourseExam, CourseExamResponse>().ReverseMap();
        CreateMap<CourseExam, CreateCourseExamCommand>().ReverseMap();
        CreateMap<CourseExam, UpdateCourseExamCommand>().ReverseMap();

        CreateMap<CourseQuestionResponse, CreateCourseQuestionCommand>().ReverseMap();
        CreateMap<CourseQuestion, CreateCourseQuestionCommand>().ReverseMap();
        CreateMap<CourseQuestion, CourseQuestionResponse>().ReverseMap();
        CreateMap<CourseQuestion, UpdateCourseQuestionCommand>().ReverseMap();
    }
}
