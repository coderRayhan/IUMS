using AspNetCoreHero.Results;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Common;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Academic.Lookup.Commands
{
    public class UpdateLookupCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NameBN { get; set; }
        public int ParentId { get; set; }
        public string Status { get; set; }

        public class UpdateLookupCommandHandler : IRequestHandler<UpdateLookupCommand, Result<int>>
        {
            private readonly ILookupRepository _lookupRepository;
            private IUnitOfWork _unitOfWork { get; set; }
            public UpdateLookupCommandHandler(ILookupRepository lookupRepository, IUnitOfWork unitOfWork)
            {
                _lookupRepository = lookupRepository;
                _unitOfWork = unitOfWork;
            }
            public async Task<Result<int>> Handle(UpdateLookupCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var lookup = await _lookupRepository.GetByIdAsync(request.Id);

                    if (lookup == null)
                    {
                        return Result<int>.Fail($"Lookup Not Found");
                    }
                    else
                    {
                        lookup.Code = request.Code;
                        lookup.Name = request.Name ?? lookup.Name;
                        lookup.NameBN = request.NameBN ?? lookup.NameBN;
                        lookup.ParentId = request.ParentId;
                        lookup.Status = request.Status == "true" ? "A" : "In";
                        await _lookupRepository.UpdateAsync(lookup);
                        await _unitOfWork.Commit(cancellationToken);
                        return Result<int>.Success(lookup.Id);
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
