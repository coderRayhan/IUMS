using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using AutoMapper;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;

namespace IUMS.Application.Features.LMS.CourseMasters.Queries
{
    public sealed record LMSCourseListByTeacherIdQuery(int TeacherId) : IRequest<Result<List<CourseMasterResponse>>>;
	internal sealed record LMSCourseListByTeacherIdQueryHandler(
		IDapperContext _dapper,
		IMapper _mapper) 
		: IRequestHandler<LMSCourseListByTeacherIdQuery, Result<List<CourseMasterResponse>>>
	{
		public async Task<Result<List<CourseMasterResponse>>> Handle(LMSCourseListByTeacherIdQuery request, CancellationToken cancellationToken)
		{
			try
			{
                var sql = "SELECT CM.Id, C.ProgramName, C.BatchName, C.SemesterName, C.CourseCode, C.CourseName, CM.CourseObjective, CM.CourseOutline, CM.CourseAssignId FROM LMS_CourseMasters CM INNER JOIN vwLMSCourseDetails C ON CM.CourseAssignId = C.CourseAssignId WHERE 1 = 1 AND CM.TeacherId = @TeacherId ORDER BY CM.Id DESC";

                using var connection = _dapper.CreateConnection();

                var data = await connection.QueryAsync<CourseMasterResponse>(sql, new { request.TeacherId });

				return Result<List<CourseMasterResponse>>.Success(_mapper.Map<List<CourseMasterResponse>>(data));
			}	
			catch (Exception ex)
			{
				return Result<List<CourseMasterResponse>>.Fail(ex.Message);
			}
		}
	}
}
