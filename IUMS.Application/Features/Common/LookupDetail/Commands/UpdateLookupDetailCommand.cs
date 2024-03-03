using AspNetCoreHero.Results;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Common;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Academic.LookupDetail.Commands;
public sealed record UpdateLookupDetailCommand 
    : IRequest<Result<int>>
{
    public int Id { get; set; }
    public string Code { get; set; }
    public int LookupId { get; set; }
    public string Name { get; set; }
    public string NameBN { get; set; }
    public int ParentId { get; set; }
    public string ParentsName { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
}
internal sealed record UpdateLookupDetailCommandHandler(
    ILookupDetailRepository _lookupDetailRepository,
    IUnitOfWork _unitOfWork)
    : IRequestHandler<UpdateLookupDetailCommand, Result<int>>
{
    public async Task<Result<int>> Handle(UpdateLookupDetailCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var lookupDetail = await _lookupDetailRepository.GetByIdAsync(request.Id);

            if (lookupDetail == null)
            {
                return Result<int>.Fail($"MasterDetails Not Found");
            }
            else
            {
                lookupDetail.Code = request.Code;
                lookupDetail.LookupId = request.LookupId;
                lookupDetail.Name = request.Name ?? lookupDetail.Name;
                lookupDetail.NameBN = request.NameBN ?? lookupDetail.NameBN;
                lookupDetail.ParentId = request.ParentId;
                lookupDetail.Description = request.Description;
                lookupDetail.Status = request.Status == "true" ? "A" : "In";
                await _lookupDetailRepository.UpdateAsync(lookupDetail);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(lookupDetail.Id);
            }
        }
        catch (Exception ex)
        {
            return Result<int>.Fail(ex.Message);
        }
    }
}
