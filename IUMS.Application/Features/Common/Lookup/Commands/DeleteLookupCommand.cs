using AspNetCoreHero.Results;
using AutoMapper;
using IUMS.Application.Constants;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Common;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Academic.Lookup.Commands
{
    public sealed record DeleteLookupCommand(int Id) : IRequest<Result<int>>;
    internal sealed record DeleteLookupCommandHandler : IRequestHandler<DeleteLookupCommand, Result<int>>
    {
        private readonly ILookupRepository _lookupRepository;
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork { get; set; }
        public DeleteLookupCommandHandler(
            ILookupRepository lookupRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _lookupRepository = lookupRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<int>> Handle(DeleteLookupCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _lookupRepository.GetByIdAsync(request.Id);
                if (entity == null)
                {
                    return Result<int>.Fail("Lookup not Exists.");
                }
                else
                {
                    await _lookupRepository.DeleteAsync(entity);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(LocalizerConstant.DELETE);
                }

            }
            catch (Exception ex)
            {

                return Result<int>.Fail(ex.Message);
            }
        }
    }
}
