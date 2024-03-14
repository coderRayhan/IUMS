using AspNetCoreHero.Results;
using AutoMapper;
using IUMS.Application.Interfaces.Contexts;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Common;
using IUMS.Domain.Entities.Common;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Common;
public sealed record CreateLookupDetailCommand 
    : IRequest<Result<int>>
{
    public string Code { get; set; }
    public int LookupId { get; set; }
    public string Name { get; set; }
    public string NameBN { get; set; }
    public int ParentId { get; set; }
    public string ParentsName { get; set; }
    public string Description { get; set; }
    public string Status { get; set; } = "A";
}

public class CreateLookupDetailCommandHandler 
    : IRequestHandler<CreateLookupDetailCommand, Result<int>>
{
    private readonly ILookupDetailRepository _lookupDetailRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDapperContext _context;

    public CreateLookupDetailCommandHandler(
        ILookupDetailRepository lookupDetailRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IDapperContext context)
    {
        _lookupDetailRepository = lookupDetailRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _context = context;
    }
    public async Task<Result<int>> Handle(CreateLookupDetailCommand request, CancellationToken cancellationToken)
    {
        try
        {

            if (await _context.IsExist("Com_LookupDetails", new string[] { "Code", "LookupId" }, new { request.Code, request.LookupId }))
            {
                return Result<int>.Fail("Code Already Exists.");
            }
            else if (await _context.IsExist("Com_LookupDetails", new string[] { "Name", "LookupId" }, new { request.Name, request.LookupId }))
            {
                return Result<int>.Fail("Name Already Exists.");
            }
            else if (await _context.IsExist("Com_LookupDetails", new string[] { "NameBN", "LookupId" }, new { request.NameBN, request.LookupId }))
            {
                return Result<int>.Fail("Name in Bangla Already Exists.");
            }
            else
            {
                var entity = _mapper.Map<LookupDetail>(request);
                entity.Status = entity.Status == "true" ? "A" : "In";
                await _lookupDetailRepository.InsertAsync(entity);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(entity.Id);
            }

        }
        catch (Exception ex)
        {

            return Result<int>.Fail(ex.Message);
        }
    }
}

