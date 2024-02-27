using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using IUMS.Application.Interfaces.Repositories.Academic;
using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;

namespace IUMS.Application.Features.Academic
{
	public class DeleteSessionCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteSessionCommandHandler : IRequestHandler<DeleteSessionCommand, Result<int>>
        {
            private readonly ISessionRepository _sessionRepository;
            private readonly IUnitOfWork _unitOfWork;
            //private readonly IDbRepository _dbRepository;

            public DeleteSessionCommandHandler(ISessionRepository sessionRepository, IUnitOfWork unitOfWork
                //, IDbRepository dbRepository
                )
            {
                _sessionRepository = sessionRepository;
                _unitOfWork = unitOfWork;
                //_dbRepository = dbRepository;
            }

            public async Task<Result<int>> Handle(DeleteSessionCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    var entity = await _sessionRepository.GetByIdAsync(command.Id);
                    await _sessionRepository.DeleteAsync(entity);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success("Delete Success");
                }
                catch (Exception ex)
                {

                    return Result<int>.Fail(ex.Message);
                }
               
            }
        }
    }
}