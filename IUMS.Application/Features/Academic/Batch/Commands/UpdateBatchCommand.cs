using AspNetCoreHero.Results;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Academic;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features
{
    public record UpdateBatchCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int FacultyId { get; set; }
        public int DepartmentId { get; set; }
        public int ProgramId { get; set; }
        public int Capacity { get; set; }
        public string BatchName { get; set; }
        public string BatchNameBN { get; set; }
        public string Code { get; set; }
        public string CodeBN { get; set; }
    }

    public record UpdateBatchCommandHandler(IBatchRepository Repository, IUnitOfWork UnitOfWork) : IRequestHandler<UpdateBatchCommand, Result<int>>
    {
        public  async Task<Result<int>> Handle(UpdateBatchCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var batch = await Repository.GetByIdAsync(command.Id);

                if (batch == null)
                {
                    return Result<int>.Fail($"batch Not Found.");
                }
                else
                {
                    batch.BatchName = command.BatchName ?? batch.BatchName;
                    batch.BatchNameBN = command.BatchNameBN ?? batch.BatchNameBN;
                    batch.Code = command.Code ?? batch.Code;
                    batch.DepartmentId = (command.DepartmentId == 0) ? batch.DepartmentId : command.DepartmentId;
                    batch.SessionId = (command.SessionId == 0) ? batch.SessionId : command.SessionId;
                    batch.ProgramId = (command.ProgramId == 0) ? batch.ProgramId : command.ProgramId;
                    batch.FacultyId = (command.FacultyId == 0) ? batch.FacultyId : command.FacultyId;
                    batch.Capacity = (command.Capacity == 0) ? batch.Capacity : command.Capacity;
                    await Repository.UpdateAsync(batch);
                    await UnitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(batch.Id);
                }
            }
            catch (Exception ex)
            {
                return Result<int>.Fail(ex.Message);
            }
            throw new NotImplementedException();
        }
    }
}
