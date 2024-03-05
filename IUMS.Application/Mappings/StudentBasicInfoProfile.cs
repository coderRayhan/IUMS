using AutoMapper;
using IUMS.Application.Features.Student.StudentBasicInfos.Commands;
using IUMS.Application.Features.Student.StudentBasicInfos.Queries;
using IUMS.Domain.Entities.Student;

namespace IUMS.Application.Mappings;
public class StudentBasicInfoProfile : Profile
{
    public StudentBasicInfoProfile()
    {
        CreateMap<StudentBasicInfo, CreateStudentBasicInfoCommand>().ReverseMap();
        CreateMap<StudentBasicInfo, UpdateStudentBasicInfoCommand>().ReverseMap();
        CreateMap<StudentBasicInfo, StudentBasicInfoResponse>().ReverseMap();

        CreateMap<StudentEducationalInfo, StudentEducationalInfoResponse>().ReverseMap();
    }
}
