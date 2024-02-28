using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using IUMS.Application.Interfaces.Repositories.Academic;
using IUMS.Application.Constants;
using IUMS.Application.Interfaces.Repositories;

namespace UEMS.Application.Features
{
    public record DeleteFacultyCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public record DeleteFacultyCommandHandler(
            IFacultyRepository FacultyRepository, 
            //IDbRepository DbRepository, 
            IUnitOfWork UnitOfWork) : IRequestHandler<DeleteFacultyCommand, Result<int>>
        {
            public async Task<Result<int>> Handle(DeleteFacultyCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    //if (await DbRepository.IsExist(DBConstants.TABLE.DEPARTMENT, string.Format(DBConstants.QUERIES.CHECK_DEPARTMENT_FACULTYID, new object[] { command.Id })))
                    //{
                    //    throw new Exception(LocalizerConstant.DATA_EXISTS);
                    //}
                    var entity = await FacultyRepository.GetByIdAsync(command.Id);
                    await FacultyRepository.DeleteAsync(entity);
                    await UnitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(LocalizerConstant.DELETE);
                }
                catch (Exception ex)
                {
                    return Result<int>.Fail(ex.Message);
                }              
            }
        }
    }
}