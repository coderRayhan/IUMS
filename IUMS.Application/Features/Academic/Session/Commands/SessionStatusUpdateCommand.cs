using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Academic;

namespace IUMS.Application.Features.Academic
{
	public class SessionStatusUpdateCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
      

        public class SessionStatusUpdateCommandHandler : IRequestHandler<SessionStatusUpdateCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ISessionRepository _sessionRepository;

            public SessionStatusUpdateCommandHandler(ISessionRepository sessionRepository, IUnitOfWork unitOfWork)
            {
                _sessionRepository = sessionRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(SessionStatusUpdateCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    var session = await _sessionRepository.GetByIdAsync(command.Id);
                    if (session != null)
                    {
                        session.Status = session.Status == "Active" ? "Inactive" : "Active";
                    }
                    await _sessionRepository.UpdateAsync(session);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success("Update Success");
                }
                catch (Exception ex)
                {

                    return Result<int>.Fail(ex.Message);
                }
               
            }
        }
    }
}