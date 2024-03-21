using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using AutoMapper;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;

namespace IUMS.Application.Features.LMS.CourseQuestions.Queries
{
    public sealed record FilteredCourseFromLMSCourseMasterQuery(int SessionId, int FacultyId, int DepartmentId, int ProgramId, int AcademicSemesterId) : IRequest<Result<List<CourseFromLMSCourseMasterResponse>>>;
	internal sealed record FilteredCourseFromLMSCourseMasterQueryHandler(IDapperContext _dapper, IMapper _mapper) : IRequestHandler<FilteredCourseFromLMSCourseMasterQuery, Result<List<CourseFromLMSCourseMasterResponse>>>
	{
		public async Task<Result<List<CourseFromLMSCourseMasterResponse>>> Handle(FilteredCourseFromLMSCourseMasterQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var sql = "SELECT CM.Id, CONCAT(C.CourseCode, ' - ', C.CourseName) AS CourseName, CA.AdmissionYearId, CA.FacultyId, CA.DepartmentId, CA.ProgramId, CA.SemesterId FROM LMS_CourseMasters AS CM INNER JOIN Aca_CourseAssigns AS CA ON CM.CourseAssignId = CA.Id INNER JOIN Aca_Courses AS C ON CA.CourseId = C.Id WHERE CA.SessionId =   @SessionId AND CA.FacultyId = @FacultyId AND CA.DepartmentId = @DepartmentId AND CA.ProgramId = @ProgramId AND CA.AcademicSemesterId = @AcademicSemesterId";

				using var connection = _dapper.CreateConnection();

				var courseList = await connection.QueryAsync<CourseFromLMSCourseMasterResponse>(sql, new { request.SessionId, request.FacultyId, request.DepartmentId, request.ProgramId, request.AcademicSemesterId });

				return Result<List<CourseFromLMSCourseMasterResponse>>.Success(_mapper.Map<List<CourseFromLMSCourseMasterResponse>>(courseList));
			}
			catch (Exception ex)
			{
				return Result<List<CourseFromLMSCourseMasterResponse>>.Fail(ex.Message);
			}
			throw new NotImplementedException();
		}
	}
}
