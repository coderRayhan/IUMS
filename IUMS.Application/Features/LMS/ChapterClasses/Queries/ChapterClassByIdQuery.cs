using System;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using AutoMapper;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;

namespace IUMS.Application.Features.LMS.ChapterClasses.Queries
{
    public record ChapterClassByIdQuery(int Id) : IRequest<Result<ChapterClassResponse>> { }
    public record GetChapterClassByIdQueryHandler(IDapperContext _dapper, IMapper _mapper) : IRequestHandler<ChapterClassByIdQuery, Result<ChapterClassResponse>>
	{
		public async Task<Result<ChapterClassResponse>> Handle(ChapterClassByIdQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var sql = "";

				using var connection = _dapper.CreateConnection();

				var entity = await connection.QueryFirstAsync(sql, new { request.Id });
				//var entity = await _repository.GetObjectBySpWithParam<ChapterClassResponse>("GetChapterClassByIdWithChapterAndCourseDetails", request.Id);

				if (entity is null)
					return Result<ChapterClassResponse>.Fail("Data not found");

				return Result<ChapterClassResponse>.Success(entity);
			}
			catch (Exception ex)
			{
				return Result<ChapterClassResponse>.Fail(ex.Message);
			}
		}
	}
}
