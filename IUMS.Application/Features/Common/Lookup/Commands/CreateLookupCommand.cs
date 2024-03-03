using AspNetCoreHero.Results;
using AutoMapper;
using IUMS.Application.Interfaces.Contexts;
using IUMS.Application.Interfaces.Repositories;
using IUMS.Application.Interfaces.Repositories.Common;
using IUMS.Domain.Entities.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IUMS.Application.Features.Common
{
    public class CreateLookupCommand : IRequest<Result<int>>
    {
        public string Code { get; set; } 
        public string Name { get; set; } 
        public string NameBN { get; set; } 
        public int ParentId { get; set; } 
        public string Status { get; set; }
    }

    public  class CreateLookupCommandHandler : IRequestHandler<CreateLookupCommand, Result<int>>
    {
        private readonly ILookupRepository _LookupRepository;
        private readonly IMapper _mapper;
        private readonly IDapperContext _dapperContext;

        private IUnitOfWork _unitOfWork { get; set; }
        public CreateLookupCommandHandler(
            ILookupRepository lookupRepository, 
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            IDapperContext dapperContext)
        {
            _LookupRepository = lookupRepository;
            _mapper = mapper;
            _dapperContext = dapperContext;
            _unitOfWork = unitOfWork;
        }
        public  async Task<Result<int>> Handle(CreateLookupCommand request, CancellationToken cancellationToken)
        {
            try
            { 
                if(await _dapperContext.IsExist("Com_Lookups", new string[] {"Code"}, new { request.Code }))
                {
                    return Result<int>.Fail("Code Already Exists.");
                }
                else if (await _dapperContext.IsExist("Com_Lookups", new string[] { "Name" }, new { request.Name }))
                {
                    return Result<int>.Fail("Name Already Exists.");
                }
                else if (await _dapperContext.IsExist("Com_Lookups", new string[] { "NameBN" }, new { request.NameBN }))
                {
                    return Result<int>.Fail("Name in Bangla Already Exists.");
                }
                else
                {
                    var entity = _mapper.Map<Lookup>(request);
                    entity.Status = entity.Status == "true" ? "A" : "In";
                    await _LookupRepository.InsertAsync(entity);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(entity.Id);
                }

                //var lookups = await _LookupRepository.GetListAsync();
                //if (lookups.Any(md => md.Code == request.Code))
                //{
                    
                //}
                //else if (lookups.Any(md => md.Name == request.Name))
                //{
                //    return Result<int>.Fail("Name Already Exists.");
                //}
                //else if (lookups.Any(md => md.NameBN == request.NameBN))
                //{
                //    return Result<int>.Fail("Name in Bangla Already Exists.");
                //}
                //else
                //{
                //    var entity = _mapper.Map<Lookup>(request);
                //    entity.Status =  entity.Status == "true" ? "A" : "In";
                //    await _LookupRepository.InsertAsync(entity);
                //    await _unitOfWork.Commit(cancellationToken);
                //    return Result<int>.Success(entity.Id);
                //} 
            }
            catch (Exception ex )
            { 
                return Result<int>.Fail(ex.Message);
            }
        }
    }
}
