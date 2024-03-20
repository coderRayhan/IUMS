using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using AutoMapper;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;

namespace IUMS.Application.Features.LMS.CourseChapters.Queries
{
    public record ChapterListByCourseMasterQuery(int CourseMasterId) : IRequest<Result<List<GetChapterListByCourseMasterResponse>>> { }
	public record GetChapterListByCourseMasterQueryHandler(
		IDapperContext _dapper,
		IMapper _mapper) 
		: IRequestHandler<ChapterListByCourseMasterQuery, Result<List<GetChapterListByCourseMasterResponse>>>
	{
		public async Task<Result<List<GetChapterListByCourseMasterResponse>>> Handle(ChapterListByCourseMasterQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var sql = "SELECT Id, Title FROM LMS_CourseChapters WHERE CourseMasterId = @CourseMasterId";

				using var connection = _dapper.CreateConnection();

				var list = await connection.QueryAsync<GetChapterListByCourseMasterResponse>(sql, new { request.CourseMasterId });

				return Result<List<GetChapterListByCourseMasterResponse>>.Success(_mapper.Map<List<GetChapterListByCourseMasterResponse>>(list));
			}
			catch (Exception ex)
			{
				return Result<List<GetChapterListByCourseMasterResponse>>.Fail(ex.Message);
			}
		}
	}
}
