using AspNetCoreHero.Results;
using AutoMapper;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.LMS.CourseAssignments.Queries
{
    public record CourseAssignmentListQuery(int SessionId, int FacultyId, int DepartmentId, int ProgramId, int BatchId, int SemesterId, int CourseId, int ChapterId, int ClassId) : IRequest<Result<List<CourseAssignmentResponse>>>
	{
	}
	public record GetAllCourseAssignmentQueryHandler(IDapperContext _dapper, IMapper _mapper) : IRequestHandler<CourseAssignmentListQuery, Result<List<CourseAssignmentResponse>>>
	{
		public async Task<Result<List<CourseAssignmentResponse>>> Handle(CourseAssignmentListQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var sql = "";

				using var connection = _dapper.CreateConnection();

				var list = await connection.QueryAsync<CourseAssignmentResponse>(sql, new { request.SessionId, request.FacultyId, request.DepartmentId, request.ProgramId, request.BatchId, request.SemesterId, request.CourseId, request.ChapterId, request.ClassId });
				//var list = await _repository.GetListBySpWithParam<CourseAssignmentResponse>(STORE_PROCEDURE.GET_ALL_LMS_COURSE_ASSIGNMENT, request.AdmissionYearId, request.FacultyId, request.DepartmentId, request.ProgramId, request.BatchId, request.SemesterId, request.CourseId, request.ChapterId, request.ClassId);
				return Result<List<CourseAssignmentResponse>>.Success(_mapper.Map<List<CourseAssignmentResponse>>(list));
			}
			catch (Exception ex)
			{
				return Result<List<CourseAssignmentResponse>>.Fail(ex.Message);
			}
		}
	}
}
