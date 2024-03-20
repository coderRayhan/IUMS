using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using AutoMapper;
using Dapper;
using IUMS.Application.Features.LMS.ChapterClasses.Queries;
using IUMS.Application.Interfaces.Contexts;
using MediatR;

namespace IUMS.Application.Features.LMS.CourseChapters.Queries
{
    public sealed record CourseChapterListByCourseAssignIdQuery(int CourseAssignId) : IRequest<Result<List<GetClassListWithChapterDetailsResponse>>>
	{
	}
	internal sealed record GetCourseChapterListByCourseAssignIdQueryHandler(
		IDapperContext _dapper,
		IMapper _mapper) : IRequestHandler<CourseChapterListByCourseAssignIdQuery, Result<List<GetClassListWithChapterDetailsResponse>>>
	{
		public async Task<Result<List<GetClassListWithChapterDetailsResponse>>> Handle(CourseChapterListByCourseAssignIdQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var sql = "SELECT Classes.Id, Chapter.CourseMasterId, Course.AdmissionYearName, Course.AdmissionYearNameBN, Course.FacultyName, Course.FacultyNameBN, Course.DepartmentName, Course.DepartmentNameBN, Course.ProgramName, Course.ProgramNameBN, Course.CourseCode, Course.CourseName, Course.ConductHour, Course.CreditHour, Course.PartName, Chapter.Id CourseChapterId, Chapter.Title ChapterTitle, Chapter.Duration ChapterDuration, CASE WHEN Classes.Title is null THEN ''  WHEN Classes.Title IS NOT NULL THEN CONCAT(Classes.Title, ' | ', Classes.Duration) END ClassDetail, Course.CourseTypeName, Course.CourseTypeNameBN, Classes.IsClassOrExam, Classes.Duration ClassDuration, EMP.FullName TeacherName FROM LMS_CourseMasters AS [Master] INNER JOIN LMS_CourseChapters AS Chapter ON Master.Id = Chapter.CourseMasterId LEFT JOIN LMS_ChapterClasses AS Classes ON Chapter.Id = Classes.CourseChapterId INNER JOIN Aca_CourseAssigns AS CA ON [Master].CourseAssignId = CA.Id INNER JOIN vwLMSCourseDetails AS Course ON [Master].Id = Course.CourseMasterId INNER JOIN Emp_Employees EMP ON [Master].TeacherId = EMP.Id WHERE [Master].Id = @CourseMasterId";

				using var connection = _dapper.CreateConnection();

				var classListWithChapterDetail = await connection.QueryAsync<GetClassListWithChapterDetailsResponse>(sql, new { request.CourseAssignId });

				return Result<List<GetClassListWithChapterDetailsResponse>>.Success(_mapper.Map<List<GetClassListWithChapterDetailsResponse>>(classListWithChapterDetail));
			}
			catch (Exception ex)
			{
				return Result<List<GetClassListWithChapterDetailsResponse>>.Fail(ex.Message);
			}
		}
	}
}
