using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Linq;
using IUMS.Application.Interfaces.Repositories.Academic;
using IUMS.Application.Interfaces.Repositories;

namespace IUMS.Application.Features.Academic
{
    public class UpdateSessionCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string SessionName { get; set; }
        public string SessionNameBN { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SessionCode { get; set; }
        public string Status { get; set; }

        public class UpdateSessionCommandHandler : IRequestHandler<UpdateSessionCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ISessionRepository _sessionRepository;

            public UpdateSessionCommandHandler(ISessionRepository sessionRepository, IUnitOfWork unitOfWork)
            {
                _sessionRepository = sessionRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateSessionCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    var session = await _sessionRepository.GetByIdAsync(command.Id);
                    var sessionDetails = await _sessionRepository.GetListAsync();
                    var execptExisting = sessionDetails.Where(s => s.Id != session.Id).ToList();
                    var lastSession = execptExisting.LastOrDefault();
                    if (session == null)
                    {
                        return Result<int>.Fail($"Session Not Found.");
                    }
                    else if (execptExisting.Any(s => s.StartDate <= command.StartDate && s.EndDate >= command.StartDate))
                    {
                        return Result<int>.Fail("Start date is already exist in another academic year");
                    }
                    else if (execptExisting.Any(s => s.StartDate <= command.EndDate && s.EndDate >= command.EndDate))
                    {
                        return Result<int>.Fail("End date is already exist in another academic year");
                    }
                    //else if (lastSession.EndDate < command.EndDate)
                    //{
                    //    return Result<int>.Fail("End date is overflow Other academic Year");
                    //}
                    else
                    {

                        session.SessionName = String.IsNullOrEmpty(command.SessionName) ? session.SessionName : command.SessionName;
                        session.SessionNameBN = String.IsNullOrEmpty(command.SessionNameBN) ? session.SessionNameBN : command.SessionNameBN;
                        session.StartDate = command.StartDate;
                        session.EndDate = command.EndDate;
                        session.SessionCode = command.SessionCode;
                        await _sessionRepository.UpdateAsync(session);
                        await _unitOfWork.Commit(cancellationToken);
                        return Result<int>.Success(session.Id);
                    }
                }
                catch (Exception ex)
                {

                    return Result<int>.Fail(ex.Message);
                }
               
            }
        }
    }
}