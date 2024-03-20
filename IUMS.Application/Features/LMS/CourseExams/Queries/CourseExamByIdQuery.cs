using System;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using AutoMapper;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IUMS.Application.Features.LMS.CourseExams.Queries
{
    public sealed record CourseExamByIdQuery(int Id) : IRequest<Result<CourseExamResponse>> { }
	internal sealed record CourseExamByIdQueryHandler(
		IDapperContext _dapper,
		IMapper _mapper) 
		: IRequestHandler<CourseExamByIdQuery, Result<CourseExamResponse>>
	{
		public async Task<Result<CourseExamResponse>> Handle(CourseExamByIdQuery request, CancellationToken cancellationToken)
		{
			try
			{
                var sql = "SELECT CE.Id, CE.CourseMasterId, CE.CourseChapterId, CE.ExamTypeId, CE.NoOfQuestions, CE.QuesToBeAnswered, CE.TotalMarks, CE.PassMark, CE.Duration, CE.StartDate, CE.StartTime, CE.EndDate, CE.EndTime, CE.IsActive, CE.PartId, CE.ChapterClassId, CA.AdmissionYearId, CA.FacultyId, CA.DepartmentId, CE.FollowedByChapterId, CA.ProgramId, CA.BatchId, CA.SemesterId, CE.ExamNameId, CE.AssignmentDetails, CE.AssignmentUrl FROM LMS_CourseExams AS CE INNER JOIN LMS_CourseMasters AS CM ON CE.CourseMasterId = CM.Id INNER JOIN Aca_CourseAssigns AS CA ON CM.CourseAssignId = CA.Id WHERE CE.Id =  @Id";

                using var connection = _dapper.CreateConnection();

                var data = await connection.QueryFirstAsync<CourseExamResponse>(sql, new { request.Id });

				if (data == null)
					return Result<CourseExamResponse>.Fail("Data not found");

				return Result<CourseExamResponse>.Success(data);
			}
			catch (Exception ex)
			{
				return Result<CourseExamResponse>.Fail(ex.Message);
			}
		}
	}
}
