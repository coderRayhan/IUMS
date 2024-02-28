using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Linq;
using IUMS.Application.Interfaces.Repositories.Academic;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Domain.Entities.Academic;

namespace IUMS.Application.Features.Academic
{
	public partial class CreateSessionCommand : IRequest<Result<int>>
    {
        public string SessionName { get; set; }
        public string SessionNameBN { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SessionCode { get; set; }
        public string Status { get; set; }

    }

    public class CreateSessionCommandHandler : IRequestHandler<CreateSessionCommand, Result<int>>
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork { get; set; }

        public CreateSessionCommandHandler(ISessionRepository sessionRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _sessionRepository = sessionRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateSessionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var sessionDetails = await _sessionRepository.GetListAsync();
                if (sessionDetails.Any(s => s.StartDate <= request.StartDate && s.EndDate >= request.StartDate))
                {
                    return Result<int>.Fail("Start date is already exist in another academic year");
                }
                else if (sessionDetails.Any(s => s.StartDate <= request.EndDate && s.EndDate >= request.EndDate))
                {
                    return Result<int>.Fail("End date is already exist in another academic year");
                }
                else
                {
                    var entity = _mapper.Map<Session>(request);
                    entity.Status = "Active";
					await _sessionRepository.InsertAsync(entity);
                    await _unitOfWork.Commit(cancellationToken);
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