using AspNetCoreHero.Results;
using AutoMapper;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Academic;
using IUMS.Domain.Entities.Academic;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features
{
    public sealed record CreateBatchCommand : IRequest<Result<int>>
    {
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

    internal sealed record CreateBatchCommandHandler(
        IBatchRepository Repository, 
        IMapper Mapper, 
        IUnitOfWork UnitOfWork) 
        : IRequestHandler<CreateBatchCommand, Result<int>>
    {
        public async Task<Result<int>> Handle(CreateBatchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await Repository.GetListAsync();
                if (list.Any(l=> l.SessionId == request.SessionId && l.ProgramId == request.ProgramId))
                {
                    return Result<int>.Fail("Same Batch Already Exits In Academic year");
                }
                else
                {
                    Batch entity = Mapper.Map<Batch>(request);
                    await Repository.InsertAsync(entity);
                    await UnitOfWork.Commit(cancellationToken);
                    return Result<int>.Success();
                }
            }
            catch (Exception ex)
            {
                return Result<int>.Fail(ex.Message);
            }
        }
    }
}
