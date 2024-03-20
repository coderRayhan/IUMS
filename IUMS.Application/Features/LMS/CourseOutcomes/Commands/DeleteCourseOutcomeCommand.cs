using System;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using Dapper;
using IUMS.Application.Interfaces.Contexts;
using MediatR;

namespace IUMS.Application.Features.LMS.CourseOutcomes.Commands
{
    public record DeleteCourseOutcomeCommand(int Id) : IRequest<Result<int>> { }
	public record DeleteCourseOutcomeCommandHandler(
		IDapperContext _dapper) : IRequestHandler<DeleteCourseOutcomeCommand, Result<int>>
	{
		public async Task<Result<int>> Handle(DeleteCourseOutcomeCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var sql = "DELETE FROM LMS_CourseOutcomes WHERE Id = @Id";

				using var connection = _dapper.CreateConnection();

				await connection.ExecuteAsync(sql, new { request.Id });

				return Result<int>.Success("Deleted Successfully");
			}
			catch (Exception ex)
			{
				return Result<int>.Fail(ex.Message);
			}
		}
	}
}
