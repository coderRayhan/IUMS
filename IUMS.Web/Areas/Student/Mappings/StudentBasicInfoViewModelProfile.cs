using AutoMapper;
using IUMS.Application.Features.Student.StudentBasicInfos.Commands;
using IUMS.Application.Features.Student.StudentBasicInfos.Queries;
using IUMS.Web.Areas.Student.Models;

namespace IUMS.Web.Areas.Student.Mappings;

public class StudentBasicInfoViewModelProfile : Profile
{
    public StudentBasicInfoViewModelProfile()
    {
        CreateMap<StudentBasicInfoViewModel, CreateStudentBasicInfoCommand>().ReverseMap();
        CreateMap<StudentBasicInfoViewModel, UpdateStudentBasicInfoCommand>().ReverseMap();
        CreateMap<StudentBasicInfoViewModel, StudentBasicInfoResponse>().ReverseMap();

        CreateMap<StudentEducationalInfoViewModel, StudentEducationalInfoResponse>().ReverseMap();
    }
}
