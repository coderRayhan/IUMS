using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using IUMS.Application.Interfaces.Repositories.Academic;
using IUMS.Application.Constants;
using IUMS.Application.Interfaces.Repositories;

namespace IUMS.Application.Features
{
    public sealed record DeleteProgramCommand(int Id) : IRequest<Result<int>>;
    internal sealed record DeleteProgramCommandHandler(
        IProgramRepository _programRepository,
        IUnitOfWork _unitOfWork) : IRequestHandler<DeleteProgramCommand, Result<int>>
    {

        public async Task<Result<int>> Handle(DeleteProgramCommand command, CancellationToken cancellationToken)
        {
            try
            {
                //if (await _dbRepository.IsExist(DBConstants.TABLE.STUDENT_BASICINFO, string.Format(DBConstants.QUERIES.CHECK_STUDENT_PROGRAMID, new object[] { command.Id })))
                //{
                //    throw new Exception(LocalizerConstant.DATA_EXISTS);
                //}
                var entity = await _programRepository.GetByIdAsync(command.Id);
                await _programRepository.DeleteAsync(entity);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(LocalizerConstant.DELETE);
            }
            catch (Exception ex)
            {

                return Result<int>.Fail(ex.Message);
            }

        }
    }
}